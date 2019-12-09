namespace EHI.Services.ServiceModel.Contact.Error
{

    /// <summary>
    /// Gets or Sets Errorcode
    /// </summary>
    public enum ErrorcodeEnum
    {
        InternalError,
        InvalidRequest,        
        RecordsNotFound,
        SQLException,

        #region Contact errors
        InvalidFirstName,        
        InvalidEmail        
        #endregion

    }
}
