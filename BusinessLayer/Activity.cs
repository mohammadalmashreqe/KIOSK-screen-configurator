namespace BusinessLayer
{
    /// <summary>
    /// Defines the activityType
    /// </summary>
    public enum activityType
    { /// <summary>
      /// Defines the print_ticket_type
      /// </summary>
        print_ticket_type,
        /// <summary>
        /// Defines the Request_identification
        /// </summary>
        Request_identification,
        /// <summary>
        /// Defines the Confirmation_activity
        /// </summary>
        Confirmation_activity
    }

    /// <summary>
    /// Defines the <see cref="Activity" />
    /// </summary>
    public abstract class Activity
    {
        /// <summary>
        /// Defines the _Information_message
        /// </summary>
        string _Information_message;

        /// <summary>
        /// Initializes a new instance of the <see cref="Activity"/> class.
        /// </summary>
        /// <param name="i">The i<see cref="string"/></param>
        public Activity(string i)
        {
            _Information_message = i;
        }

        /// <summary>
        /// Gets or sets the Information_message
        /// </summary>
        public string Information_message
        {
            set
            {
                _Information_message = value;
            }
            get
            {
                return _Information_message;
            }
        }
    }
}
