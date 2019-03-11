using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayWeb.Models.Interface
{
    public interface IState
    {
        IEnumerable<State> GetAllState();
        State GetStateById(int StateId);
        void EditState(State state);
        void DeleteState(State state);
        void AddState(State state);
    }
}
