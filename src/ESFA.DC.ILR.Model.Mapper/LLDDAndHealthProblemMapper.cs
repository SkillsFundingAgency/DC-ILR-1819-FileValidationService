using System;
using ESFA.DC.ILR.Model.Mapper.Abstract;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class LLDDAndHealthProblemMapper : AbstractModelMapper<Loose.MessageLearnerLLDDandHealthProblem, MessageLearnerLLDDandHealthProblem>
    {
        protected override MessageLearnerLLDDandHealthProblem MapModel(Loose.MessageLearnerLLDDandHealthProblem model)
        {
            return new MessageLearnerLLDDandHealthProblem()
            {
                LLDDCat = (int)model.LLDDCat,
                PrimaryLLDD = (int)model.PrimaryLLDD,
                PrimaryLLDDSpecified = model.PrimaryLLDDSpecified,
            };
        }
    }
}
