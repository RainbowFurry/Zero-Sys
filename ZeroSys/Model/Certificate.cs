namespace ZeroSys.Model
{
    /// <summary>
    /// Certificate
    /// </summary>
    public class Certificate
    {

        #region Default Values
        public string DisplayName { get; set; }
        public string DomainName { get; set; }
        public string Title { get; set; } //T
        public string Description { get; set; }
        public string FullName { get; set; } //DN
        public string FirstName { get; set; } //G
        public string SecondName { get; set; } //SN
        public string Email { get; set; } //E
        public string Country { get; set; } //C
        public string Place { get; set; } //L
        public string Street { get; set; } //street
        public string Organisation { get; set; } //O
        public CertificateType CertType { get; set; }
        public int Duration_Days { get; set; }
        public int Duration_Months { get; set; }
        public int Duration_Years { get; set; }
        public string Password { get; set; }
        public string DNS { get; set; }
        #endregion

        #region Alternate Names
        //
        #endregion

        #region Key Use
        //
        #endregion

        #region Key Use Extended
        //
        #endregion

        #region Custom Key Values
        //
        #endregion

    }

    /// <summary>
    /// Certification Types
    /// </summary>
    public enum CertificateType
    {
        PFX,
        CER,
        SNK,
    }

}
