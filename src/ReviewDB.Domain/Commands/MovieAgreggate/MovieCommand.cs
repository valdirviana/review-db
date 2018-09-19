using ReviewDB.Domain.Core.Commands;
using System;

namespace ReviewDB.Domain.Commands.MovieAgreggate
{
    public abstract class MovieCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
    }
}
