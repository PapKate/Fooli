using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fooli
{
    /// <summary>
    /// Represents a label in the database
    /// </summary>
    public class LabelEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The slug
        /// </summary>
        public string Slug { get; set; }

        #region Relationships

        /// <summary>
        /// The labels and products
        /// </summary>
        public IEnumerable<ProductLabelEntity> ProductLabels { get; set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public LabelEntity()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns a <see cref="LabelEntity"/> from the specified <paramref name="model"/>
        /// <paramref name="model">The model</paramref>
        /// </summary>
        /// <returns></returns>
        public static LabelEntity FromRequestModel(LabelRequestModel model)
            => ControllersHelper.FromRequestModel<LabelEntity, LabelRequestModel>(model);

        /// <summary>
        /// Creates and returns a <see cref="LabelResponseModel"/> from the current <see cref="ImageEntity"/>
        /// </summary>
        /// <returns></returns>
        public LabelResponseModel ToResponseModel()
            => ControllersHelper.ToResponseModel<LabelEntity, LabelResponseModel>(this);

        #endregion
    }
}
