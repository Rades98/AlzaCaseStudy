﻿namespace API.Middleware
{
    using ApplicationLayer.Exceptions;
    using ApplicationLayer.Exceptions.Order;
    using ApplicationLayer.Exceptions.OrderItem;
    using ApplicationLayer.Services.OrderItems.Commands.Delete;
    using ApplicationLayer.Services.OrderItems.Commands.Put;
    using ApplicationLayer.Services.Orders.Commands.Storno;
    using Models;
    using System.Net;

    /// <summary>
    /// Exception middleware 
    /// Handles exception message in case of production environment
    /// Logging is not necessary here due the fact that serilog
    /// has its own http request logging middleware
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var message = "Internal server error";

            //Dont forget to add any of exception type to controllers as producing response
            switch (e)
            {
                case TimeoutException _:
                    message = "Request time out";
                    context.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                    break;
                case BadHttpRequestException _:
                    message = "Bad request";
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case UserLoginException uex:
                    message = uex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
               
                case OrderItemPutException oip:
                    message = oip.Message;

                    switch(oip.Message)
                    {
                        case OrderItemPutRequestMessages.OrderNotFound:
                        case OrderItemPutRequestMessages.ProductNotFound:
                            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                        case OrderItemPutRequestMessages.AdditionFailed:
                        case OrderItemPutRequestMessages.OrderUneditable:
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            break;
                    }
                    break;

                case OrderItemDeleteException oid:
                    switch (oid.Message)
                    {
                        case OrderItemDeleteRequestMessages.NotFound:
                            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                            break;

                        case OrderItemDeleteRequestMessages.Error:
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            break;
                    }
                    break;

                case OrderDeleteException od:
                    message = od.Message;
                    switch (od.Message)
                    {
                        case OrderStornoRequestMessages.Error:
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            break;
                        case OrderStornoRequestMessages.NotFound:
                            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                            break;
                        case OrderStornoRequestMessages.CannotBeCanceled:
                            context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                            break;
                    }
                    break;
                    //and so on...
            }

            return context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
