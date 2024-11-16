namespace MLService.Infrastructure
{
    public static class Constants
    {
        #region Exceptions
        /// <summary>
        /// Неизвестный тип БД
        /// </summary>
        public const string UndefineDbException = "Неизвестный тип БД";

        /// <summary>
        /// Этот объект уже удалена
        /// </summary>
        public const string DeleteDeletabedEntityException = "Этот объект уже удалена";

        /// <summary>
        /// Этот объект не удален
        /// </summary>
        public const string ObjectNotDeleted = "Этот объект не удален";
        #endregion
    }
}
