using System;
using System.Collections.Generic;
using System.Text;
using ESFA.DC.ILR.Model.Mapper.Abstract;
using ESFA.DC.ILR.Model.Mapper.Extension;

namespace ESFA.DC.ILR.Model.Mapper
{
    public class LearningDeliveryHEMapper : AbstractModelMapper<Loose.MessageLearnerLearningDeliveryLearningDeliveryHE, MessageLearnerLearningDeliveryLearningDeliveryHE>
    {
        protected override MessageLearnerLearningDeliveryLearningDeliveryHE MapModel(Loose.MessageLearnerLearningDeliveryLearningDeliveryHE model)
        {
            return  new MessageLearnerLearningDeliveryLearningDeliveryHE()
            {
                DOMICILE = model.DOMICILE.Sanitize(),
                ELQ = (int)model.ELQ,
                ELQSpecified = model.ELQSpecified,
                FUNDCOMP = (int)model.FUNDCOMP,
                FUNDLEV = (int)model.FUNDLEV,
                GROSSFEE = (int)model.GROSSFEE,
                GROSSFEESpecified = model.GROSSFEESpecified,
                HEPostCode = model.HEPostCode.Sanitize(),
                MODESTUD = (int)model.MODESTUD,
                MSTUFEE = (int)model.MSTUFEE,
                NETFEE = (int)model.NETFEE,
                NETFEESpecified = model.NETFEESpecified,
                NUMHUS = model.NUMHUS.Sanitize(),
                PCFLDCS = model.PCFLDCS,
                PCFLDCSSpecified = model.PCFLDCSSpecified,
                PCOLAB = model.PCOLAB,
                PCOLABSpecified = model.PCOLABSpecified,
                PCSLDCS = model.PCSLDCS,
                PCSLDCSSpecified = model.PCSLDCSSpecified,
                PCTLDCS = model.PCTLDCS,
                PCTLDCSSpecified = model.PCTLDCSSpecified,
                QUALENT3 = model.QUALENT3.Sanitize(),
                SEC = (int)model.SEC,
                SECSpecified = model.SECSpecified,
                SOC2000 = (int)model.SOC2000,
                SOC2000Specified = model.SOC2000Specified,
                SPECFEE = (int)model.SPECFEE,
                SSN = model.SSN.Sanitize(),
                STULOAD = model.STULOAD,
                STULOADSpecified = model.STULOADSpecified,
                TYPEYR = (int)model.TYPEYR,
                UCASAPPID = model.UCASAPPID.Sanitize(),
                YEARSTU = (int)model.YEARSTU,
            };
        }
    }
}
