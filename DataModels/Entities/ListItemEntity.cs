using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fooli
{
    /// <summary>
    /// Represents a list item in the database
    /// </summary>
    public class ListItemEntity
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// The item
        /// </summary>
        public string Item { get; set; }

        #region Relationships

        /// <summary>
        /// The <see cref="ListEntity.Id"/> of the related <see cref="ListEntity"/>
        /// </summary>
        public int ListId { get; set; }

        /// <summary>
        /// The related <see cref="ListEntity"/>
        /// </summary>
        public ListEntity List { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ListItemEntity()
        {

        }

        #endregion

    }
}
