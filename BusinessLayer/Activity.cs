namespace BusinessLayer
{

    public enum ActivityType
    {
        ConfirmationActivity,
        PrintTicketType,
        RequestIdentification


    }

    /// <summary>
    /// Defines the <see cref="Activity" />
    /// </summary>
    public abstract class Activity
    {
        /// <summary>
        /// Defines the _Information_message
        /// </summary>
        private string _informationMessage;

        private ActivityType _type;
        private int _id;

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

        public ActivityType Type
        {
            get => _type;
            set => _type = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

     
    }
}
