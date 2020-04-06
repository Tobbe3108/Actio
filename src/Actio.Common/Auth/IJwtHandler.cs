using System;

namespace Actio.Common.Auth
{
    public interface IJwtHandler
    {
        JsonWebToken Crete(Guid userId);
    }
}