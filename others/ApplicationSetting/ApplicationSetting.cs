namespace ApplicationSetting
{
	//This is for dev purposes.. it should be all stored in app settings (json) or better in db maybe
	public static class ApplicationSetting
	{
		public const int RegistrationActivationDelay = 14;

		public const int MAX_USERNAME_LENGHT = 20;
		public const int MIN_USERNAME_LENGHT = 5;

		public const int MAX_PW_LENGHT = 40;
		public const int MIN_PW_LENGHT = 10;

		public const int MAX_FIRSTNAME_LENGHT = 20;
		public const int MIN_FIRSTNAME_LENGHT = 2;

		public const int MAX_SURNAME_LENGHT = 20;
		public const int MIN_SURNAME_LENGHT = 2;

		public const int CACHE_EXPIRATION_TIME_MINS = 15;
		public const int CACHE_SLIDING_EXPIRATION_TIME_MINS = 2;

		public const int MAX_DESCRIPTION_LENGHT = 250;
		public const int MIN_DESCRIPTION_LENGHT = 40;

	}
}