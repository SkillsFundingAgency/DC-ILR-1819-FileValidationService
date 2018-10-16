namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseEmploymentStatusMonitoring
    {
        string ESMType { get; }

        long? ESMCodeNullable { get; }
    }
}
