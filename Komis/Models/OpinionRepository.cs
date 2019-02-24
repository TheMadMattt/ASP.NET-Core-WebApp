﻿namespace Komis.Models
{
	public class OpinionRepository : IOpinionRepository
	{
		private readonly AppDbContext _appDbContext;

		public OpinionRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public void AddOpinion(Opinion opinion)
		{
			_appDbContext.Opinions.Add(opinion);
			_appDbContext.SaveChanges();
		}
	}
}
