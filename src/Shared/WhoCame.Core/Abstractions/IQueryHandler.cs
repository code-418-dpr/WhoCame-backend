﻿using WhoCame.SharedKernel;

namespace WhoCame.Core.Abstractions;

public interface IQueryHandler<TResponse, in TQuery> where TQuery : IQuery
{
    public Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken = default);
}