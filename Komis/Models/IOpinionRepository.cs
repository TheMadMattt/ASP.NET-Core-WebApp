﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Komis.Models
{
	public interface IOpinionRepository
	{
		void AddOpinion(Opinion opinion);
	}
}
