﻿using Extensions.Hosting.AsyncInitialization;
using Microsoft.EntityFrameworkCore;

namespace WhoCame.Accounts.Infrastructure;

public class DbInitializer(AccountsDbContext dbContext) : IAsyncInitializer
{
    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        await dbContext.Database.MigrateAsync(cancellationToken);
    }
}