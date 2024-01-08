using System;
using CommandSystem;
using RemoteAdmin;

namespace PreGameLobby.Commands
{
    class DeathMatchCom
    {
		[CommandHandler(typeof(RemoteAdminCommandHandler))]
		class HelloWorld : ICommand
		{
			public string Command { get; } = "DeathMatch";

			public string[] Aliases { get; } = new string[] { "DeathFight" };

			public string Description { get; } = "Starts the death match in the pregame lobby.";

			public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
			{
				if (sender is PlayerCommandSender player)
				{
					if (player.CheckPermission(PlayerPermissions.AdminChat))
                    {
						if (PreGameLobby.Instance.Config.Death)
                        {
							if (PreGameLobby.Instance.PreGameLobbyRunNow)
							{
								if (PreGameLobby.Instance.PreGameLobbyEvent)
								{
									response = "There is already an event running";
								}
								else
								{
									response = "Starting death match";
									Events.DeathMatch.PreGameLobbyDeathMatch();
								}
							}
							else
							{
								response = "This can only be ran while the pre game lobby is running";
							}
						}
						else
                        {
							response = "The server owner has disabled this command";
                        }
                    }
                    else
                    {
						response = "You don't have permission to use this command";
                    }
					return false;
				}
				else
				{
					if (PreGameLobby.Instance.Config.Death)
					{
						if (PreGameLobby.Instance.PreGameLobbyRunNow)
						{
							if (PreGameLobby.Instance.PreGameLobbyEvent)
							{
								response = "There is already an event running";
							}
							else
							{
								response = "Starting death match";
								Events.DeathMatch.PreGameLobbyDeathMatch();
							}
						}
						else
						{
							response = "This can only be ran while the pre game lobby is running";
						}
					}
					else
					{
						response = "This command is disabled";
					}
					return true;
				}
			}
		}
	}
}
