using System;
using System.Collections.Generic;
using System.Data;
using WiW.src.Clasificador;
using WiW.src.IDato;

namespace tpf
{
    
	public abstract class SFactory
    {

        public static ISorter New(RawData data)
		{
			(Choice, RawData[]) i = data.BestQuery();
			if (i == default)
				return new SLeaf(data.ToHashSet());
			return new SParent(i.Item1, i.Item2);
		}
	}
}
