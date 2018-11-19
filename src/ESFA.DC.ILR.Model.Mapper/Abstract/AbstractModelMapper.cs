using System;
using System.Collections.Generic;
using System.Text;
using ESFA.DC.ILR.Model.Mapper.Interface;

namespace ESFA.DC.ILR.Model.Mapper.Abstract
{
    public abstract class AbstractModelMapper<TIn, TOut> : IModelMapper<TIn, TOut>
    {
        public TOut Map(TIn model)
        {
            if (model == null)
            {
                return default(TOut);
            }

            return MapModel(model);

        }

        protected abstract TOut MapModel(TIn model);
    }
}
