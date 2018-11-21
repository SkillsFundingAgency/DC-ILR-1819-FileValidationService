using ESFA.DC.ILR.Model.Mapper.Abstract;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class LearnerHEFinancialSupportMapper : AbstractModelMapper<Loose.MessageLearnerLearnerHELearnerHEFinancialSupport, MessageLearnerLearnerHELearnerHEFinancialSupport>
    {
        protected override MessageLearnerLearnerHELearnerHEFinancialSupport MapModel(Loose.MessageLearnerLearnerHELearnerHEFinancialSupport model)
        {
            return new MessageLearnerLearnerHELearnerHEFinancialSupport()
            {
                FINAMOUNT = (int)model.FINAMOUNT,
                FINTYPE = (int)model.FINTYPE,
            };
        }
    }
}
