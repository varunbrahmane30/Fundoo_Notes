//-----------------------------------------------------------------------
// <copyright file="ILabelBL.cs" 
// </copyright>
// <author>Varun Brahmane</author>
//-----------------------------------------------------------------------
namespace BusinessLayer.Interface
{
    using CommonLayer;

    /// <summary>
    ///   <br />
    /// </summary>
    public interface ILabelBL
    {
        public bool AddLabel(long noteId, AddLabelRequest label);

        public bool DeleteLabel(long labelId);

        public bool UpdateLabel(long labelId, AddLabelRequest label);
    }
}
