using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fooli
{
    /// <summary>
    /// An entity with and Id plus <see cref="BaseEntity"/>
    /// </summary>
    public class StandardEntity : BaseEntity
    {
        #region Public Properties
        
        /// <summary>
        /// The id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public StandardEntity()
        {

        }

        #endregion
    }
}
