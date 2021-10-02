//-----------------------------------------------------------------------
// <copyright file="ICollaboratorBL.cs" company="Company">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Varun Brahmane</author>
//-----------------------------------------------------------------------
namespace BusinessLayer.Interface
{
    using System.Collections.Generic;
    using CommonLayer;

    /// <summary>
    ///   <br />
    /// </summary>
    public interface ICollaboratorBL
    {
        /// <summary>Gets the collaborators identifier.</summary>
        /// <param name="noteId">The note identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public List<string> GetCollaboratorsId(long noteId);

        /// <summary>Adds the collborators.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="collaborators">The collaborators.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public bool AddCollborators(long userId, long id, AddCollaboratorRequest collaborators);

        /// <summary>Deletes the collborators.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="collaborators">The collaborators.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public bool DeleteCollborators(long userId, long id, AddCollaboratorRequest collaborators);
    }

}
