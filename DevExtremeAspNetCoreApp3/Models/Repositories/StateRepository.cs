using HolidayWeb.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models.Repositories
{
    public class StateRepository : IState
    {
        private readonly AppDbContext _appDbContext;
        public StateRepository(AppDbContext AppDbContext)
        {
            _appDbContext = AppDbContext;
        }


        public State GetStateById(int StateId)
        {
            return _appDbContext.States.FirstOrDefault(p => p.Id == StateId);
        }

        public IEnumerable<State> GetAllState()
        {
            return _appDbContext.States;
        }

        public void EditState(State state)
        {
            _appDbContext.States.Update(state);
            _appDbContext.SaveChanges();
        }
        public void DeleteState(State state)
        {
            _appDbContext.States.Remove(state);
            _appDbContext.SaveChanges();
        }

        public void AddState(State state)
        {
            _appDbContext.States.Add(state);
            _appDbContext.SaveChanges();
        }

    }
}
