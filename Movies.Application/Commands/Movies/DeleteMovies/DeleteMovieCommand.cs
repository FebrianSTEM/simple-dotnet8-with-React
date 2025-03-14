using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Commands.Movies.DeleteMovies;

public record DeleteMovieCommand(int Id) : IRequest<Unit>;