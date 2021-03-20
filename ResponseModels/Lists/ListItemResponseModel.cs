using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fooli
{
    public class ListItemResponseModel
    {
        /// <summary>
        /// The id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The item
        /// </summary>
        public string Item { get; set; }

        /// <summary>
        /// The <see cref="ListEntity.Id"/> of the related <see cref="ListEntity"/>
        /// </summary>
        public int ListId { get; set; }
    }
}
