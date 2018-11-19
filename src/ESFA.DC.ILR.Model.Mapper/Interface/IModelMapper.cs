namespace ESFA.DC.ILR.Model.Mapper.Interface
{
    public interface IModelMapper<in TIn, out TOut>
    {
        TOut Map(TIn model);
    }
}
