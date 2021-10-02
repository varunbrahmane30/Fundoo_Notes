namespace RepositoryLayer.Interface
{
    using CommonLayer;

    public interface ILabelRL
    {
        public bool AddLabel(long noteId,AddLabelRequest label);
        public bool DeleteLabel(long labelId);
        public bool UpdateLabel(long labelId, AddLabelRequest label);

    }
}
