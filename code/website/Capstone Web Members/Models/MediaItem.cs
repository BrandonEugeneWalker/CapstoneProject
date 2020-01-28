namespace Capstone_Web_Members.Models
{
    /// <summary>
    ///     Superclass for media items in the system
    /// </summary>
    public class MediaItem
    {
        //TODO Define and add media types OR classes defining this types more explicitly
        /// <summary>
        ///     Defines the different media types a MediaItem can be
        /// </summary>
        public enum MediaType
        {
            Book,
            MusicCd,
            Movie
        }

        /// <summary>
        ///     Gets or sets the product identifier.
        /// </summary>
        /// <value>
        ///     The product identifier.
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        //TODO might need to be more specific with subclasses (Author/writer for book, artist for CD, etc.)
        /// <summary>
        ///     Gets or sets the author.
        /// </summary>
        /// <value>
        ///     The author.
        /// </value>
        public string Author { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public MediaType Type { get; set; }
    }
}