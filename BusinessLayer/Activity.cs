namespace BusinessLayer
{
    /// <summary>
    /// Defines the <see cref="Activity" />
    /// </summary>
    public abstract class Activity
    {
        /// <summary>
        /// Defines the _Information_message
        /// </summary>
        private string _informationMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="Activity"/> class.
        /// </summary>
        /// <param name="i">The i<see cref="string"/></param>
        protected Activity(string i)
        {
            _informationMessage = i;
        }

        /// <summary>
        /// Gets or sets the Information_message
        /// </summary>
        public string InformationMessage
        {
            set=>_informationMessage = value;
            
            get=> _informationMessage;
            
        }
    }
}
