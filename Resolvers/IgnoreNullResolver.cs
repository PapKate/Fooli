using AutoMapper;

namespace Fooli
{
    /// <summary>
    /// Resolver used for using the destination member value when the source member is null.
    /// NOTE: This resolver is sued when mapping values from a request model to a database entity! 
    /// </summary>
    public class IgnoreNullResolver : IMemberValueResolver<object, object, object, object>
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public IgnoreNullResolver()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Implementors use source object to provide a destination object.
        /// </summary>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object</param>
        /// <param name="sourceMember">Source member</param>
        /// <param name="destinationMember">Destination member</param>
        /// <param name="context">The context of the mapping</param>
        /// <returns></returns>
        public object Resolve(object source, object destination, object sourceMember, object destinationMember, ResolutionContext context)
        {
            // Returns the source member if not null, else the destination member
            return sourceMember ?? destinationMember;
        }
        
        #endregion

    }
}
