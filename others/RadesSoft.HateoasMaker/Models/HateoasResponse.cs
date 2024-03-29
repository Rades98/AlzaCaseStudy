﻿using System.Text.Json.Serialization;

namespace RadesSoft.HateoasMaker.Models
{
	public class HateoasResponse
	{
		public string ActionName { get; set; } = string.Empty;
		public HateoasResponseBody? Curl { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public object? RequestModel { get; set; } = null;
	}
}
