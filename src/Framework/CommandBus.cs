﻿using System.Windows.Input;

namespace Framework;
public class CommandBus : ICommandBus
{
    private readonly ICommandHandlerResolver _resolver;

    public CommandBus(ICommandHandlerResolver resolver)
    {
        _resolver = resolver;
    }
    public async Task Dispatch<T>(T command) where T : class, ICommand
    {
        var handlers = _resolver.ResolveHandlers(command).ToList();
        foreach (var handler in handlers)
        {
            await handler.Handle(command);
        }
    }
}