using System.Linq;
using ESFA.DC.ILR.Model.Mapper.Abstract;
using ESFA.DC.ILR.Model.Mapper.Interface;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class LearnerHEMapper : AbstractModelMapper<Loose.MessageLearnerLearnerHE, MessageLearnerLearnerHE>
    {
        private readonly IModelMapper<Loose.MessageLearnerLearnerHELearnerHEFinancialSupport, MessageLearnerLearnerHELearnerHEFinancialSupport> _learnerHeFinancialSupportMapper;

        public LearnerHEMapper(IModelMapper<Loose.MessageLearnerLearnerHELearnerHEFinancialSupport, MessageLearnerLearnerHELearnerHEFinancialSupport> learnerHEFinancialSupportMapper)
        {
            _learnerHeFinancialSupportMapper = learnerHEFinancialSupportMapper;
        }

        protected override MessageLearnerLearnerHE MapModel(Loose.MessageLearnerLearnerHE model)
        {
            return new MessageLearnerLearnerHE()
            {
                LearnerHEFinancialSupport = model.LearnerHEFinancialSupport?.Select(s => _learnerHeFinancialSupportMapper.Map(s)).ToArray(),
                TTACCOM = (int)model.TTACCOM,
                TTACCOMSpecified = model.TTACCOMSpecified,
                UCASPERID = model.UCASPERID,
            };
        }
    }
}
