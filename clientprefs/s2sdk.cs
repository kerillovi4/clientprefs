using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Plugify;

// Generated with https://github.com/untrustedmodders/plugify-module-dotnet/blob/main/generator/generator.py from s2sdk

namespace s2sdk {
#pragma warning disable CS0649

	/// <summary>
	/// Enum representing the possible results of an operation.
	/// </summary>
	public enum ResultType : int
	{
		/// <summary>
		/// The action continues to be processed without interruption.
		/// </summary>
		Continue = 0,
		/// <summary>
		/// Indicates that the action has altered the state or behavior during execution.
		/// </summary>
		Changed = 1,
		/// <summary>
		/// The action has been successfully handled, and no further action is required.
		/// </summary>
		Handled = 2,
		/// <summary>
		/// The action processing is halted, and no further steps will be executed.
		/// </summary>
		Stop = 3,
	}

	/// <summary>
	/// Represents the possible types of data that can be passed as a value in input actions.
	/// </summary>
	public enum FieldType : int
	{
		/// <summary>
		/// Automatically detect the type of the value.
		/// </summary>
		Auto = 0,
		/// <summary>
		/// A 32-bit floating-point number.
		/// </summary>
		Float32 = 1,
		/// <summary>
		/// A 64-bit floating-point number.
		/// </summary>
		Float64 = 2,
		/// <summary>
		/// A 32-bit signed integer.
		/// </summary>
		Int32 = 3,
		/// <summary>
		/// A 32-bit unsigned integer.
		/// </summary>
		UInt32 = 4,
		/// <summary>
		/// A 64-bit signed integer.
		/// </summary>
		Int64 = 5,
		/// <summary>
		/// A 64-bit unsigned integer.
		/// </summary>
		UInt64 = 6,
		/// <summary>
		/// A boolean value (true or false).
		/// </summary>
		Boolean = 7,
		/// <summary>
		/// A single character.
		/// </summary>
		Character = 8,
		/// <summary>
		/// A managed string object.
		/// </summary>
		String = 9,
		/// <summary>
		/// A null-terminated C-style string.
		/// </summary>
		CString = 10,
		/// <summary>
		/// A script handle, typically for scripting integration.
		/// </summary>
		HScript = 11,
		/// <summary>
		/// An entity handle, used to reference an entity within the system.
		/// </summary>
		EHandle = 12,
		/// <summary>
		/// A resource handle, such as a file or asset reference.
		/// </summary>
		Resource = 13,
		/// <summary>
		/// A 3D vector, typically representing position or direction.
		/// </summary>
		Vector3d = 14,
		/// <summary>
		/// A 2D vector, for planar data or coordinates.
		/// </summary>
		Vector2d = 15,
		/// <summary>
		/// A 4D vector, often used for advanced mathematical representations.
		/// </summary>
		Vector4d = 16,
		/// <summary>
		/// A 32-bit color value (RGBA).
		/// </summary>
		Color32 = 17,
		/// <summary>
		/// A quaternion-based angle representation.
		/// </summary>
		QAngle = 18,
		/// <summary>
		/// A quaternion, used for rotation and orientation calculations.
		/// </summary>
		Quaternion = 19,
	}

	/// <summary>
	/// Enum representing the possible verbosity of a logger.
	/// </summary>
	public enum LoggingVerbosity : int
	{
		/// <summary>
		/// Turns off all spew.
		/// </summary>
		Off = 0,
		/// <summary>
		/// Turns on vital logs.
		/// </summary>
		Essential = 1,
		/// <summary>
		/// Turns on most messages.
		/// </summary>
		Default = 2,
		/// <summary>
		/// Allows for walls of text that are usually useful.
		/// </summary>
		Detailed = 3,
		/// <summary>
		/// Allows everything.
		/// </summary>
		Max = 4,
	}

	/// <summary>
	/// Enum representing the possible verbosity of a logger.
	/// </summary>
	public enum LoggingSeverity : int
	{
		/// <summary>
		/// Turns off all spew.
		/// </summary>
		Off = 0,
		/// <summary>
		/// A debug message.
		/// </summary>
		Detailed = 1,
		/// <summary>
		/// An informative logging message.
		/// </summary>
		Message = 2,
		/// <summary>
		/// A warning, typically non-fatal.
		/// </summary>
		Warning = 3,
		/// <summary>
		/// A message caused by an Assert**() operation.
		/// </summary>
		Assert = 4,
		/// <summary>
		/// An error, typically fatal/unrecoverable.
		/// </summary>
		Error = 5,
	}

	/// <summary>
	/// Logging channel behavior flags, set on channel creation.
	/// </summary>
	public enum LoggingChannelFlags : int
	{
		/// <summary>
		/// Indicates that the spew is only relevant to interactive consoles.
		/// </summary>
		ConsoleOnly = 1,
		/// <summary>
		/// Indicates that spew should not be echoed to any output devices.
		/// </summary>
		DoNotEcho = 2,
	}



	/// <summary>
	/// Handles the execution of a command triggered by a caller. This function processes the command, interprets its context, and handles any provided arguments.
	/// </summary>
	public delegate ResultType CommandCallback(int caller, int context, string[] arguments);
	/// <summary>
	/// Handles changes to a console variable's value. This function is called whenever the value of a specific console variable is modified.
	/// </summary>
	public delegate void ChangeCallback(nint pConVar, string newValue, string oldValue);
	/// <summary>
	/// Defines a QueueTask Callback.
	/// </summary>
	public delegate void TaskCallback(object?[] userData);
	/// <summary>
	/// This function is a callback handler for entity output events. It is triggered when a specific output event is activated, and it handles the process by passing the activator, the caller, and a delay parameter for the output.
	/// </summary>
	public delegate ResultType HookEntityOutputCallback(int activatorHandle, int callerHandle, float flDelay);
	/// <summary>
	/// Handles events triggered by the game event system. This function processes the event data, determines the necessary action, and optionally prevents event broadcasting.
	/// </summary>
	public delegate ResultType EventCallback(string name, nint event_, Bool8 dontBroadcast);
	/// <summary>
	/// This function is invoked when a timer event occurs. It handles the timer-related logic and performs necessary actions based on the event.
	/// </summary>
	public delegate void TimerCallback(nint timer, object?[] userData);
	/// <summary>
	/// Called on client connection. If you return true, the client will be allowed in the server. If you return false (or return nothing), the client will be rejected. If the client is rejected by this forward or any other, OnClientDisconnect will not be called.<br>Note: Do not write to rejectmsg if you plan on returning true. If multiple plugins write to the string buffer, it is not defined which plugin's string will be shown to the client, but it is guaranteed one of them will.
	/// </summary>
	public delegate Bool8 OnClientConnectCallback(int clientIndex, string name, string networkId);
	/// <summary>
	/// Called on client connection.
	/// </summary>
	public delegate void OnClientConnect_PostCallback(int clientIndex);
	/// <summary>
	/// Called once a client successfully connects. This callback is paired with OnClientDisconnect.
	/// </summary>
	public delegate void OnClientConnectedCallback(int clientIndex);
	/// <summary>
	/// Called when a client is entering the game.
	/// </summary>
	public delegate void OnClientPutInServerCallback(int clientIndex);
	/// <summary>
	/// Called when a client is disconnecting from the server.
	/// </summary>
	public delegate void OnClientDisconnectCallback(int clientIndex);
	/// <summary>
	/// Called when a client is disconnected from the server.
	/// </summary>
	public delegate void OnClientDisconnect_PostCallback(int clientIndex, int reason);
	/// <summary>
	/// Called when a client is activated by the game.
	/// </summary>
	public delegate void OnClientActiveCallback(int clientIndex, Bool8 isActive);
	/// <summary>
	/// Called when a client is fully connected to the game.
	/// </summary>
	public delegate void OnClientFullyConnectCallback(int clientIndex);
	/// <summary>
	/// Called when the map starts loading.
	/// </summary>
	public delegate void OnLevelInitCallback(string mapName, string mapEntities);
	/// <summary>
	/// Called right before a map ends.
	/// </summary>
	public delegate void OnLevelShutdownCallback();
	/// <summary>
	/// Called when an entity is spawned.
	/// </summary>
	public delegate void OnEntitySpawnedCallback(nint entity);
	/// <summary>
	/// Called when an entity is created.
	/// </summary>
	public delegate void OnEntityCreatedCallback(nint entity);
	/// <summary>
	/// Called when when an entity is destroyed.
	/// </summary>
	public delegate void OnEntityDeletedCallback(nint entity);
	/// <summary>
	/// When an entity is reparented to another entity.
	/// </summary>
	public delegate void OnEntityParentChangedCallback(nint entity, nint newParent);
	/// <summary>
	/// Called on every server startup.
	/// </summary>
	public delegate void OnServerStartupCallback();
	/// <summary>
	/// Called on every server activate.
	/// </summary>
	public delegate void OnServerActivateCallback();
	/// <summary>
	/// Called before every server frame. Note that you should avoid doing expensive computations or declaring large local arrays.
	/// </summary>
	public delegate void OnGameFrameCallback(Bool8 simulating, Bool8 firstTick, Bool8 lastTick);
	public delegate void OnUpdateWhenNotInGameCallback(float deltaTime);
	public delegate void OnPreWorldUpdateCallback(Bool8 simulating);



	internal static unsafe class s2sdk {

		/// <summary>
		/// Retrieves the client index from a given entity pointer.
		/// </summary>
		/// <param name="entity">A pointer to the entity (CBaseEntity*).</param>
		/// <returns>The client index if valid, otherwise -1.</returns>

		internal static delegate*<nint, int> GetClientIndexFromEntityPointer = &___GetClientIndexFromEntityPointer;
		internal static delegate* unmanaged[Cdecl]<nint, int> __GetClientIndexFromEntityPointer;
		private static int ___GetClientIndexFromEntityPointer(nint entity)
		{
			int __retVal = __GetClientIndexFromEntityPointer(entity);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the client object from a given client index.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <returns>A pointer to the client object if found, otherwise nullptr.</returns>

		internal static delegate*<int, nint> GetClientFromIndex = &___GetClientFromIndex;
		internal static delegate* unmanaged[Cdecl]<int, nint> __GetClientFromIndex;
		private static nint ___GetClientFromIndex(int clientIndex)
		{
			nint __retVal = __GetClientFromIndex(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the index of a given client object.
		/// </summary>
		/// <param name="client">A pointer to the client object (CServerSideClient*).</param>
		/// <returns>The client index if found, otherwise -1.</returns>

		internal static delegate*<nint, int> GetIndexFromClient = &___GetIndexFromClient;
		internal static delegate* unmanaged[Cdecl]<nint, int> __GetIndexFromClient;
		private static int ___GetIndexFromClient(nint client)
		{
			int __retVal = __GetIndexFromClient(client);
			return __retVal;
		}

		/// <summary>
		/// Retrieves a client's authentication string (SteamID).
		/// </summary>
		/// <param name="clientIndex">Index of the client whose authentication string is being retrieved.</param>
		/// <returns>The authentication string.</returns>

		internal static delegate*<int, string> GetClientAuthId = &___GetClientAuthId;
		internal static delegate* unmanaged[Cdecl]<int, String192> __GetClientAuthId;
		private static string ___GetClientAuthId(int clientIndex)
		{
			string __retVal;
			String192 __retVal_native;

			try {
				__retVal_native = __GetClientAuthId(clientIndex);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
			}
			return __retVal;
		}

		/// <summary>
		/// Returns the client's Steam account ID, a unique number identifying a given Steam account.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <returns>Steam account ID.</returns>

		internal static delegate*<int, ulong> GetClientAccountId = &___GetClientAccountId;
		internal static delegate* unmanaged[Cdecl]<int, ulong> __GetClientAccountId;
		private static ulong ___GetClientAccountId(int clientIndex)
		{
			ulong __retVal = __GetClientAccountId(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Retrieves a client's IP address.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <returns>The IP address.</returns>

		internal static delegate*<int, string> GetClientIp = &___GetClientIp;
		internal static delegate* unmanaged[Cdecl]<int, String192> __GetClientIp;
		private static string ___GetClientIp(int clientIndex)
		{
			string __retVal;
			String192 __retVal_native;

			try {
				__retVal_native = __GetClientIp(clientIndex);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
			}
			return __retVal;
		}

		/// <summary>
		/// Returns the client's name.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <returns>The client's name.</returns>

		internal static delegate*<int, string> GetClientName = &___GetClientName;
		internal static delegate* unmanaged[Cdecl]<int, String192> __GetClientName;
		private static string ___GetClientName(int clientIndex)
		{
			string __retVal;
			String192 __retVal_native;

			try {
				__retVal_native = __GetClientName(clientIndex);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
			}
			return __retVal;
		}

		/// <summary>
		/// Returns the client's connection time in seconds.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <returns>float Connection time in seconds.</returns>

		internal static delegate*<int, float> GetClientTime = &___GetClientTime;
		internal static delegate* unmanaged[Cdecl]<int, float> __GetClientTime;
		private static float ___GetClientTime(int clientIndex)
		{
			float __retVal = __GetClientTime(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Returns the client's current latency (RTT).
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <returns>float Latency value.</returns>

		internal static delegate*<int, float> GetClientLatency = &___GetClientLatency;
		internal static delegate* unmanaged[Cdecl]<int, float> __GetClientLatency;
		private static float ___GetClientLatency(int clientIndex)
		{
			float __retVal = __GetClientLatency(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Returns the client's access flags.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <returns>uint64 Access flags as a bitmask.</returns>

		internal static delegate*<int, ulong> GetUserFlagBits = &___GetUserFlagBits;
		internal static delegate* unmanaged[Cdecl]<int, ulong> __GetUserFlagBits;
		private static ulong ___GetUserFlagBits(int clientIndex)
		{
			ulong __retVal = __GetUserFlagBits(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Sets the access flags on a client using a bitmask.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <param name="flags">Bitmask representing the flags to be set.</param>

		internal static delegate*<int, ulong, void> SetUserFlagBits = &___SetUserFlagBits;
		internal static delegate* unmanaged[Cdecl]<int, ulong, void> __SetUserFlagBits;
		private static void ___SetUserFlagBits(int clientIndex, ulong flags)
		{
			__SetUserFlagBits(clientIndex, flags);
		}

		/// <summary>
		/// Adds access flags to a client.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <param name="flags">Bitmask representing the flags to be added.</param>

		internal static delegate*<int, ulong, void> AddUserFlags = &___AddUserFlags;
		internal static delegate* unmanaged[Cdecl]<int, ulong, void> __AddUserFlags;
		private static void ___AddUserFlags(int clientIndex, ulong flags)
		{
			__AddUserFlags(clientIndex, flags);
		}

		/// <summary>
		/// Removes access flags from a client.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <param name="flags">Bitmask representing the flags to be removed.</param>

		internal static delegate*<int, ulong, void> RemoveUserFlags = &___RemoveUserFlags;
		internal static delegate* unmanaged[Cdecl]<int, ulong, void> __RemoveUserFlags;
		private static void ___RemoveUserFlags(int clientIndex, ulong flags)
		{
			__RemoveUserFlags(clientIndex, flags);
		}

		/// <summary>
		/// Checks if a certain player has been authenticated.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <returns>true if the player is authenticated, false otherwise.</returns>

		internal static delegate*<int, Bool8> IsClientAuthorized = &___IsClientAuthorized;
		internal static delegate* unmanaged[Cdecl]<int, Bool8> __IsClientAuthorized;
		private static Bool8 ___IsClientAuthorized(int clientIndex)
		{
			Bool8 __retVal = __IsClientAuthorized(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Checks if a certain player is connected.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <returns>true if the player is connected, false otherwise.</returns>

		internal static delegate*<int, Bool8> IsClientConnected = &___IsClientConnected;
		internal static delegate* unmanaged[Cdecl]<int, Bool8> __IsClientConnected;
		private static Bool8 ___IsClientConnected(int clientIndex)
		{
			Bool8 __retVal = __IsClientConnected(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Checks if a certain player has entered the game.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <returns>true if the player is in the game, false otherwise.</returns>

		internal static delegate*<int, Bool8> IsClientInGame = &___IsClientInGame;
		internal static delegate* unmanaged[Cdecl]<int, Bool8> __IsClientInGame;
		private static Bool8 ___IsClientInGame(int clientIndex)
		{
			Bool8 __retVal = __IsClientInGame(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Checks if a certain player is the SourceTV bot.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <returns>true if the client is the SourceTV bot, false otherwise.</returns>

		internal static delegate*<int, Bool8> IsClientSourceTV = &___IsClientSourceTV;
		internal static delegate* unmanaged[Cdecl]<int, Bool8> __IsClientSourceTV;
		private static Bool8 ___IsClientSourceTV(int clientIndex)
		{
			Bool8 __retVal = __IsClientSourceTV(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Checks if the client is alive or dead.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <returns>true if the client is alive, false if dead.</returns>

		internal static delegate*<int, Bool8> IsClientAlive = &___IsClientAlive;
		internal static delegate* unmanaged[Cdecl]<int, Bool8> __IsClientAlive;
		private static Bool8 ___IsClientAlive(int clientIndex)
		{
			Bool8 __retVal = __IsClientAlive(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Checks if a certain player is a fake client.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <returns>true if the client is a fake client, false otherwise.</returns>

		internal static delegate*<int, Bool8> IsFakeClient = &___IsFakeClient;
		internal static delegate* unmanaged[Cdecl]<int, Bool8> __IsFakeClient;
		private static Bool8 ___IsFakeClient(int clientIndex)
		{
			Bool8 __retVal = __IsFakeClient(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Retrieves a client's team index.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <returns>int The team index of the client.</returns>

		internal static delegate*<int, int> GetClientTeam = &___GetClientTeam;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetClientTeam;
		private static int ___GetClientTeam(int clientIndex)
		{
			int __retVal = __GetClientTeam(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Returns the client's health.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <returns>int The health value of the client.</returns>

		internal static delegate*<int, int> GetClientHealth = &___GetClientHealth;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetClientHealth;
		private static int ___GetClientHealth(int clientIndex)
		{
			int __retVal = __GetClientHealth(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Returns the client's armor value.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <returns>int The armor value of the client.</returns>

		internal static delegate*<int, int> GetClientArmor = &___GetClientArmor;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetClientArmor;
		private static int ___GetClientArmor(int clientIndex)
		{
			int __retVal = __GetClientArmor(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the client's origin vector.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <returns>A Vector where the client's origin will be stored.</returns>

		internal static delegate*<int, Vector3> GetClientAbsOrigin = &___GetClientAbsOrigin;
		internal static delegate* unmanaged[Cdecl]<int, Vector3> __GetClientAbsOrigin;
		private static Vector3 ___GetClientAbsOrigin(int clientIndex)
		{
			Vector3 __retVal = __GetClientAbsOrigin(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the client's position angle.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <returns>A QAngle where the client's position angle will be stored.</returns>

		internal static delegate*<int, Vector3> GetClientAbsAngles = &___GetClientAbsAngles;
		internal static delegate* unmanaged[Cdecl]<int, Vector3> __GetClientAbsAngles;
		private static Vector3 ___GetClientAbsAngles(int clientIndex)
		{
			Vector3 __retVal = __GetClientAbsAngles(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the client's eye angle.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <returns>A QAngle where the client's eye angle will be stored.</returns>

		internal static delegate*<int, Vector3> GetClientEyeAngles = &___GetClientEyeAngles;
		internal static delegate* unmanaged[Cdecl]<int, Vector3> __GetClientEyeAngles;
		private static Vector3 ___GetClientEyeAngles(int clientIndex)
		{
			Vector3 __retVal = __GetClientEyeAngles(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Processes the target string to determine if one user can target another.
		/// </summary>
		/// <param name="caller">Index of the client making the target request.</param>
		/// <param name="target">The target string specifying the player or players to be targeted.</param>
		/// <returns>A vector where the result of the targeting operation will be stored.</returns>

		internal static delegate*<int, string, int[]> ProcessTargetString = &___ProcessTargetString;
		internal static delegate* unmanaged[Cdecl]<int, String192*, Vector192> __ProcessTargetString;
		private static int[] ___ProcessTargetString(int caller, string target)
		{
			int[] __retVal;
			Vector192 __retVal_native;
			var __target = NativeMethods.ConstructString(target);

			try {
				__retVal_native = __ProcessTargetString(caller, &__target);
				// Unmarshal - Convert native data to managed data.
				__retVal = new int[NativeMethods.GetVectorSizeInt32(&__retVal_native)];
				NativeMethods.GetVectorDataInt32(&__retVal_native, __retVal);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyVectorInt32(&__retVal_native);
				NativeMethods.DestroyString(&__target);
			}
			return __retVal;
		}

		/// <summary>
		/// Changes a client's team.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <param name="team">The team index to assign the client to.</param>

		internal static delegate*<int, int, void> ChangeClientTeam = &___ChangeClientTeam;
		internal static delegate* unmanaged[Cdecl]<int, int, void> __ChangeClientTeam;
		private static void ___ChangeClientTeam(int clientIndex, int team)
		{
			__ChangeClientTeam(clientIndex, team);
		}

		/// <summary>
		/// Switches the player's team.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <param name="team">The team index to switch the client to.</param>

		internal static delegate*<int, int, void> SwitchClientTeam = &___SwitchClientTeam;
		internal static delegate* unmanaged[Cdecl]<int, int, void> __SwitchClientTeam;
		private static void ___SwitchClientTeam(int clientIndex, int team)
		{
			__SwitchClientTeam(clientIndex, team);
		}

		/// <summary>
		/// Respawns a player.
		/// </summary>
		/// <param name="clientIndex">Index of the client to respawn.</param>

		internal static delegate*<int, void> RespawnClient = &___RespawnClient;
		internal static delegate* unmanaged[Cdecl]<int, void> __RespawnClient;
		private static void ___RespawnClient(int clientIndex)
		{
			__RespawnClient(clientIndex);
		}

		/// <summary>
		/// Forces a player to commit suicide.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <param name="explode">If true, the client will explode upon death.</param>
		/// <param name="force">If true, the suicide will be forced.</param>

		internal static delegate*<int, Bool8, Bool8, void> ForcePlayerSuicide = &___ForcePlayerSuicide;
		internal static delegate* unmanaged[Cdecl]<int, Bool8, Bool8, void> __ForcePlayerSuicide;
		private static void ___ForcePlayerSuicide(int clientIndex, Bool8 explode, Bool8 force)
		{
			__ForcePlayerSuicide(clientIndex, explode, force);
		}

		/// <summary>
		/// Disconnects a client from the server as soon as the next frame starts.
		/// </summary>
		/// <param name="clientIndex">Index of the client to be kicked.</param>

		internal static delegate*<int, void> KickClient = &___KickClient;
		internal static delegate* unmanaged[Cdecl]<int, void> __KickClient;
		private static void ___KickClient(int clientIndex)
		{
			__KickClient(clientIndex);
		}

		/// <summary>
		/// Bans a client for a specified duration.
		/// </summary>
		/// <param name="clientIndex">Index of the client to be banned.</param>
		/// <param name="duration">Duration of the ban in seconds.</param>
		/// <param name="kick">If true, the client will be kicked immediately after being banned.</param>

		internal static delegate*<int, float, Bool8, void> BanClient = &___BanClient;
		internal static delegate* unmanaged[Cdecl]<int, float, Bool8, void> __BanClient;
		private static void ___BanClient(int clientIndex, float duration, Bool8 kick)
		{
			__BanClient(clientIndex, duration, kick);
		}

		/// <summary>
		/// Bans an identity (either an IP address or a Steam authentication string).
		/// </summary>
		/// <param name="steamId">The Steam ID to ban.</param>
		/// <param name="duration">Duration of the ban in seconds.</param>
		/// <param name="kick">If true, the client will be kicked immediately after being banned.</param>

		internal static delegate*<ulong, float, Bool8, void> BanIdentity = &___BanIdentity;
		internal static delegate* unmanaged[Cdecl]<ulong, float, Bool8, void> __BanIdentity;
		private static void ___BanIdentity(ulong steamId, float duration, Bool8 kick)
		{
			__BanIdentity(steamId, duration, kick);
		}

		/// <summary>
		/// Retrieves the handle of the client's currently active weapon.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <returns>The entity handle of the active weapon, or INVALID_EHANDLE_INDEX if the client is invalid or has no active weapon.</returns>

		internal static delegate*<int, int> GetClientActiveWeapon = &___GetClientActiveWeapon;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetClientActiveWeapon;
		private static int ___GetClientActiveWeapon(int clientIndex)
		{
			int __retVal = __GetClientActiveWeapon(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Retrieves a list of weapon handles owned by the client.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <returns>A vector of entity handles for the client's weapons, or an empty vector if the client is invalid or has no weapons.</returns>

		internal static delegate*<int, int[]> GetClientWeapons = &___GetClientWeapons;
		internal static delegate* unmanaged[Cdecl]<int, Vector192> __GetClientWeapons;
		private static int[] ___GetClientWeapons(int clientIndex)
		{
			int[] __retVal;
			Vector192 __retVal_native;

			try {
				__retVal_native = __GetClientWeapons(clientIndex);
				// Unmarshal - Convert native data to managed data.
				__retVal = new int[NativeMethods.GetVectorSizeInt32(&__retVal_native)];
				NativeMethods.GetVectorDataInt32(&__retVal_native, __retVal);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyVectorInt32(&__retVal_native);
			}
			return __retVal;
		}

		/// <summary>
		/// Forces a player to drop their weapon.
		/// </summary>
		/// <param name="clientIndex">Index of the client.</param>
		/// <param name="weaponHandle">Handle of weapon to drop.</param>
		/// <param name="target">Target direction.</param>
		/// <param name="velocity">Velocity to toss weapon or zero to just drop weapon.</param>

		internal static delegate*<int, int, Vector3, Vector3, void> DropWeapon = &___DropWeapon;
		internal static delegate* unmanaged[Cdecl]<int, int, Vector3*, Vector3*, void> __DropWeapon;
		private static void ___DropWeapon(int clientIndex, int weaponHandle, Vector3 target, Vector3 velocity)
		{
			__DropWeapon(clientIndex, weaponHandle, &target, &velocity);
		}

		/// <summary>
		/// Removes all weapons from a client, with an option to remove the suit as well.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <param name="removeSuit">A boolean indicating whether to also remove the client's suit.</param>

		internal static delegate*<int, Bool8, void> StripWeapons = &___StripWeapons;
		internal static delegate* unmanaged[Cdecl]<int, Bool8, void> __StripWeapons;
		private static void ___StripWeapons(int clientIndex, Bool8 removeSuit)
		{
			__StripWeapons(clientIndex, removeSuit);
		}

		/// <summary>
		/// Bumps a player's weapon.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <param name="weaponHandle">Handle of weapon to bump.</param>

		internal static delegate*<int, int, void> BumpWeapon = &___BumpWeapon;
		internal static delegate* unmanaged[Cdecl]<int, int, void> __BumpWeapon;
		private static void ___BumpWeapon(int clientIndex, int weaponHandle)
		{
			__BumpWeapon(clientIndex, weaponHandle);
		}

		/// <summary>
		/// Switches a player's weapon.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <param name="weaponHandle">Handle of weapon to switch.</param>

		internal static delegate*<int, int, void> SwitchWeapon = &___SwitchWeapon;
		internal static delegate* unmanaged[Cdecl]<int, int, void> __SwitchWeapon;
		private static void ___SwitchWeapon(int clientIndex, int weaponHandle)
		{
			__SwitchWeapon(clientIndex, weaponHandle);
		}

		/// <summary>
		/// Removes a player's weapon.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <param name="weaponHandle">Handle of weapon to remove.</param>

		internal static delegate*<int, int, void> RemoveWeapon = &___RemoveWeapon;
		internal static delegate* unmanaged[Cdecl]<int, int, void> __RemoveWeapon;
		private static void ___RemoveWeapon(int clientIndex, int weaponHandle)
		{
			__RemoveWeapon(clientIndex, weaponHandle);
		}

		/// <summary>
		/// Gives a named item (e.g., weapon) to a client.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <param name="itemName">The name of the item to give.</param>
		/// <returns>The entity handle of the created item, or INVALID_EHANDLE_INDEX if the client or item is invalid.</returns>

		internal static delegate*<int, string, int> GiveNamedItem = &___GiveNamedItem;
		internal static delegate* unmanaged[Cdecl]<int, String192*, int> __GiveNamedItem;
		private static int ___GiveNamedItem(int clientIndex, string itemName)
		{
			int __retVal;
			var __itemName = NativeMethods.ConstructString(itemName);

			try {
				__retVal = __GiveNamedItem(clientIndex, &__itemName);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__itemName);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the state of a specific button for a client.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <param name="buttonIndex">The index of the button (0-2).</param>
		/// <returns>The state of the specified button, or 0 if the client or button index is invalid.</returns>

		internal static delegate*<int, int, ulong> GetClientButtons = &___GetClientButtons;
		internal static delegate* unmanaged[Cdecl]<int, int, ulong> __GetClientButtons;
		private static ulong ___GetClientButtons(int clientIndex, int buttonIndex)
		{
			ulong __retVal = __GetClientButtons(clientIndex, buttonIndex);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the amount of money a client has.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <returns>The amount of money the client has, or 0 if the client index is invalid.</returns>

		internal static delegate*<int, int> GetClientMoney = &___GetClientMoney;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetClientMoney;
		private static int ___GetClientMoney(int clientIndex)
		{
			int __retVal = __GetClientMoney(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Sets the amount of money for a client.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <param name="money">The amount of money to set.</param>

		internal static delegate*<int, int, void> SetClientMoney = &___SetClientMoney;
		internal static delegate* unmanaged[Cdecl]<int, int, void> __SetClientMoney;
		private static void ___SetClientMoney(int clientIndex, int money)
		{
			__SetClientMoney(clientIndex, money);
		}

		/// <summary>
		/// Retrieves the number of kills for a client.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <returns>The number of kills the client has, or 0 if the client index is invalid.</returns>

		internal static delegate*<int, int> GetClientKills = &___GetClientKills;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetClientKills;
		private static int ___GetClientKills(int clientIndex)
		{
			int __retVal = __GetClientKills(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Sets the number of kills for a client.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <param name="kills">The number of kills to set.</param>

		internal static delegate*<int, int, void> SetClientKills = &___SetClientKills;
		internal static delegate* unmanaged[Cdecl]<int, int, void> __SetClientKills;
		private static void ___SetClientKills(int clientIndex, int kills)
		{
			__SetClientKills(clientIndex, kills);
		}

		/// <summary>
		/// Retrieves the number of deaths for a client.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <returns>The number of deaths the client has, or 0 if the client index is invalid.</returns>

		internal static delegate*<int, int> GetClientDeaths = &___GetClientDeaths;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetClientDeaths;
		private static int ___GetClientDeaths(int clientIndex)
		{
			int __retVal = __GetClientDeaths(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Sets the number of deaths for a client.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <param name="deaths">The number of deaths to set.</param>

		internal static delegate*<int, int, void> SetClientDeaths = &___SetClientDeaths;
		internal static delegate* unmanaged[Cdecl]<int, int, void> __SetClientDeaths;
		private static void ___SetClientDeaths(int clientIndex, int deaths)
		{
			__SetClientDeaths(clientIndex, deaths);
		}

		/// <summary>
		/// Retrieves the number of assists for a client.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <returns>The number of assists the client has, or 0 if the client index is invalid.</returns>

		internal static delegate*<int, int> GetClientAssists = &___GetClientAssists;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetClientAssists;
		private static int ___GetClientAssists(int clientIndex)
		{
			int __retVal = __GetClientAssists(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Sets the number of assists for a client.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <param name="assists">The number of assists to set.</param>

		internal static delegate*<int, int, void> SetClientAssists = &___SetClientAssists;
		internal static delegate* unmanaged[Cdecl]<int, int, void> __SetClientAssists;
		private static void ___SetClientAssists(int clientIndex, int assists)
		{
			__SetClientAssists(clientIndex, assists);
		}

		/// <summary>
		/// Retrieves the total damage dealt by a client.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <returns>The total damage dealt by the client, or 0 if the client index is invalid.</returns>

		internal static delegate*<int, int> GetClientDamage = &___GetClientDamage;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetClientDamage;
		private static int ___GetClientDamage(int clientIndex)
		{
			int __retVal = __GetClientDamage(clientIndex);
			return __retVal;
		}

		/// <summary>
		/// Sets the total damage dealt by a client.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <param name="damage">The amount of damage to set.</param>

		internal static delegate*<int, int, void> SetClientDamage = &___SetClientDamage;
		internal static delegate* unmanaged[Cdecl]<int, int, void> __SetClientDamage;
		private static void ___SetClientDamage(int clientIndex, int damage)
		{
			__SetClientDamage(clientIndex, damage);
		}

		/// <summary>
		/// Creates a console command as an administrative command.
		/// </summary>
		/// <param name="name">The name of the console command.</param>
		/// <param name="adminFlags">The admin flags that indicate which admin level can use this command.</param>
		/// <param name="description">A brief description of what the command does.</param>
		/// <param name="flags">Command flags that define the behavior of the command.</param>
		/// <param name="callback">A callback function that is invoked when the command is executed.</param>
		/// <remarks>
		/// Callback CommandCallback: Handles the execution of a command triggered by a caller. This function processes the command, interprets its context, and handles any provided arguments.
		/// - Parameter caller: An identifier for the entity or object invoking the command. Typically used to track the source of the command.
		/// - Parameter context: The context in which the command is being executed. This value can be used to provide additional information about the environment or state related to the command.
		/// - Parameter arguments: An array of strings representing the arguments passed to the command. These arguments define the parameters or options provided by the caller.
		/// - Returns: Indicates the result of the action execution. (int32)
		/// </remarks>

		internal static delegate*<string, long, string, long, CommandCallback, void> AddAdminCommand = &___AddAdminCommand;
		internal static delegate* unmanaged[Cdecl]<String192*, long, String192*, long, nint, void> __AddAdminCommand;
		private static void ___AddAdminCommand(string name, long adminFlags, string description, long flags, CommandCallback callback)
		{
			var __name = NativeMethods.ConstructString(name);
			var __description = NativeMethods.ConstructString(description);
			var __callback = Marshalling.GetFunctionPointerForDelegate(callback);

			try {
				__AddAdminCommand(&__name, adminFlags, &__description, flags, __callback);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
				NativeMethods.DestroyString(&__description);
			}
		}

		/// <summary>
		/// Creates a console command or hooks an already existing one.
		/// </summary>
		/// <param name="name">The name of the console command.</param>
		/// <param name="description">A brief description of what the command does.</param>
		/// <param name="flags">Command flags that define the behavior of the command.</param>
		/// <param name="callback">A callback function that is invoked when the command is executed.</param>
		/// <remarks>
		/// Callback CommandCallback: Handles the execution of a command triggered by a caller. This function processes the command, interprets its context, and handles any provided arguments.
		/// - Parameter caller: An identifier for the entity or object invoking the command. Typically used to track the source of the command.
		/// - Parameter context: The context in which the command is being executed. This value can be used to provide additional information about the environment or state related to the command.
		/// - Parameter arguments: An array of strings representing the arguments passed to the command. These arguments define the parameters or options provided by the caller.
		/// - Returns: Indicates the result of the action execution. (int32)
		/// </remarks>

		internal static delegate*<string, string, long, CommandCallback, void> AddConsoleCommand = &___AddConsoleCommand;
		internal static delegate* unmanaged[Cdecl]<String192*, String192*, long, nint, void> __AddConsoleCommand;
		private static void ___AddConsoleCommand(string name, string description, long flags, CommandCallback callback)
		{
			var __name = NativeMethods.ConstructString(name);
			var __description = NativeMethods.ConstructString(description);
			var __callback = Marshalling.GetFunctionPointerForDelegate(callback);

			try {
				__AddConsoleCommand(&__name, &__description, flags, __callback);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
				NativeMethods.DestroyString(&__description);
			}
		}

		/// <summary>
		/// Removes a console command from the system.
		/// </summary>
		/// <param name="name">The name of the command to be removed.</param>
		/// <param name="callback">The callback function associated with the command to be removed.</param>
		/// <remarks>
		/// Callback CommandCallback: Handles the execution of a command triggered by a caller. This function processes the command, interprets its context, and handles any provided arguments.
		/// - Parameter caller: An identifier for the entity or object invoking the command. Typically used to track the source of the command.
		/// - Parameter context: The context in which the command is being executed. This value can be used to provide additional information about the environment or state related to the command.
		/// - Parameter arguments: An array of strings representing the arguments passed to the command. These arguments define the parameters or options provided by the caller.
		/// - Returns: Indicates the result of the action execution. (int32)
		/// </remarks>

		internal static delegate*<string, CommandCallback, void> RemoveCommand = &___RemoveCommand;
		internal static delegate* unmanaged[Cdecl]<String192*, nint, void> __RemoveCommand;
		private static void ___RemoveCommand(string name, CommandCallback callback)
		{
			var __name = NativeMethods.ConstructString(name);
			var __callback = Marshalling.GetFunctionPointerForDelegate(callback);

			try {
				__RemoveCommand(&__name, __callback);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
			}
		}

		/// <summary>
		/// Adds a callback that will fire when a command is sent to the server.
		/// </summary>
		/// <param name="name">The name of the command.</param>
		/// <param name="callback">The callback function that will be invoked when the command is executed.</param>
		/// <param name="post">A boolean indicating whether the callback should fire after the command is executed.</param>
		/// <remarks>
		/// Callback CommandCallback: Handles the execution of a command triggered by a caller. This function processes the command, interprets its context, and handles any provided arguments.
		/// - Parameter caller: An identifier for the entity or object invoking the command. Typically used to track the source of the command.
		/// - Parameter context: The context in which the command is being executed. This value can be used to provide additional information about the environment or state related to the command.
		/// - Parameter arguments: An array of strings representing the arguments passed to the command. These arguments define the parameters or options provided by the caller.
		/// - Returns: Indicates the result of the action execution. (int32)
		/// </remarks>

		internal static delegate*<string, CommandCallback, Bool8, void> AddCommandListener = &___AddCommandListener;
		internal static delegate* unmanaged[Cdecl]<String192*, nint, Bool8, void> __AddCommandListener;
		private static void ___AddCommandListener(string name, CommandCallback callback, Bool8 post)
		{
			var __name = NativeMethods.ConstructString(name);
			var __callback = Marshalling.GetFunctionPointerForDelegate(callback);

			try {
				__AddCommandListener(&__name, __callback, post);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
			}
		}

		/// <summary>
		/// Removes a callback that fires when a command is sent to the server.
		/// </summary>
		/// <param name="name">The name of the command.</param>
		/// <param name="callback">The callback function to be removed.</param>
		/// <param name="post">A boolean indicating whether the callback should be removed for post-execution.</param>
		/// <remarks>
		/// Callback CommandCallback: Handles the execution of a command triggered by a caller. This function processes the command, interprets its context, and handles any provided arguments.
		/// - Parameter caller: An identifier for the entity or object invoking the command. Typically used to track the source of the command.
		/// - Parameter context: The context in which the command is being executed. This value can be used to provide additional information about the environment or state related to the command.
		/// - Parameter arguments: An array of strings representing the arguments passed to the command. These arguments define the parameters or options provided by the caller.
		/// - Returns: Indicates the result of the action execution. (int32)
		/// </remarks>

		internal static delegate*<string, CommandCallback, Bool8, void> RemoveCommandListener = &___RemoveCommandListener;
		internal static delegate* unmanaged[Cdecl]<String192*, nint, Bool8, void> __RemoveCommandListener;
		private static void ___RemoveCommandListener(string name, CommandCallback callback, Bool8 post)
		{
			var __name = NativeMethods.ConstructString(name);
			var __callback = Marshalling.GetFunctionPointerForDelegate(callback);

			try {
				__RemoveCommandListener(&__name, __callback, post);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
			}
		}

		/// <summary>
		/// Executes a server command as if it were run on the server console or through RCON.
		/// </summary>
		/// <param name="command">The command to execute on the server.</param>

		internal static delegate*<string, void> ServerCommand = &___ServerCommand;
		internal static delegate* unmanaged[Cdecl]<String192*, void> __ServerCommand;
		private static void ___ServerCommand(string command)
		{
			var __command = NativeMethods.ConstructString(command);

			try {
				__ServerCommand(&__command);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__command);
			}
		}

		/// <summary>
		/// Executes a server command as if it were on the server console (or RCON) and stores the printed text into buffer.
		/// </summary>
		/// <param name="command">The command to execute on the server.</param>
		/// <returns>String to store command result into.</returns>

		internal static delegate*<string, string> ServerCommandEx = &___ServerCommandEx;
		internal static delegate* unmanaged[Cdecl]<String192*, String192> __ServerCommandEx;
		private static string ___ServerCommandEx(string command)
		{
			string __retVal;
			String192 __retVal_native;
			var __command = NativeMethods.ConstructString(command);

			try {
				__retVal_native = __ServerCommandEx(&__command);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
				NativeMethods.DestroyString(&__command);
			}
			return __retVal;
		}

		/// <summary>
		/// Executes a client command.
		/// </summary>
		/// <param name="clientIndex">The index of the client executing the command.</param>
		/// <param name="command">The command to execute on the client.</param>

		internal static delegate*<int, string, void> ClientCommand = &___ClientCommand;
		internal static delegate* unmanaged[Cdecl]<int, String192*, void> __ClientCommand;
		private static void ___ClientCommand(int clientIndex, string command)
		{
			var __command = NativeMethods.ConstructString(command);

			try {
				__ClientCommand(clientIndex, &__command);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__command);
			}
		}

		/// <summary>
		/// Executes a client command on the server without network communication.
		/// </summary>
		/// <param name="clientIndex">The index of the client.</param>
		/// <param name="command">The command to be executed by the client.</param>

		internal static delegate*<int, string, void> FakeClientCommand = &___FakeClientCommand;
		internal static delegate* unmanaged[Cdecl]<int, String192*, void> __FakeClientCommand;
		private static void ___FakeClientCommand(int clientIndex, string command)
		{
			var __command = NativeMethods.ConstructString(command);

			try {
				__FakeClientCommand(clientIndex, &__command);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__command);
			}
		}

		/// <summary>
		/// Sends a message to the server console.
		/// </summary>
		/// <param name="msg">The message to be sent to the server console.</param>

		internal static delegate*<string, void> PrintToServer = &___PrintToServer;
		internal static delegate* unmanaged[Cdecl]<String192*, void> __PrintToServer;
		private static void ___PrintToServer(string msg)
		{
			var __msg = NativeMethods.ConstructString(msg);

			try {
				__PrintToServer(&__msg);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__msg);
			}
		}

		/// <summary>
		/// Sends a message to a client's console.
		/// </summary>
		/// <param name="clientIndex">Index of the client to whom the message will be sent.</param>
		/// <param name="message">The message to be sent to the client's console.</param>

		internal static delegate*<int, string, void> PrintToConsole = &___PrintToConsole;
		internal static delegate* unmanaged[Cdecl]<int, String192*, void> __PrintToConsole;
		private static void ___PrintToConsole(int clientIndex, string message)
		{
			var __message = NativeMethods.ConstructString(message);

			try {
				__PrintToConsole(clientIndex, &__message);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__message);
			}
		}

		/// <summary>
		/// Prints a message to a specific client in the chat area.
		/// </summary>
		/// <param name="clientIndex">Index of the client to whom the message will be sent.</param>
		/// <param name="message">The message to be printed in the chat area.</param>

		internal static delegate*<int, string, void> PrintToChat = &___PrintToChat;
		internal static delegate* unmanaged[Cdecl]<int, String192*, void> __PrintToChat;
		private static void ___PrintToChat(int clientIndex, string message)
		{
			var __message = NativeMethods.ConstructString(message);

			try {
				__PrintToChat(clientIndex, &__message);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__message);
			}
		}

		/// <summary>
		/// Prints a message to a specific client in the center of the screen.
		/// </summary>
		/// <param name="clientIndex">Index of the client to whom the message will be sent.</param>
		/// <param name="message">The message to be printed in the center of the screen.</param>

		internal static delegate*<int, string, void> PrintCenterText = &___PrintCenterText;
		internal static delegate* unmanaged[Cdecl]<int, String192*, void> __PrintCenterText;
		private static void ___PrintCenterText(int clientIndex, string message)
		{
			var __message = NativeMethods.ConstructString(message);

			try {
				__PrintCenterText(clientIndex, &__message);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__message);
			}
		}

		/// <summary>
		/// Prints a message to a specific client with an alert box.
		/// </summary>
		/// <param name="clientIndex">Index of the client to whom the message will be sent.</param>
		/// <param name="message">The message to be printed in the alert box.</param>

		internal static delegate*<int, string, void> PrintAlertText = &___PrintAlertText;
		internal static delegate* unmanaged[Cdecl]<int, String192*, void> __PrintAlertText;
		private static void ___PrintAlertText(int clientIndex, string message)
		{
			var __message = NativeMethods.ConstructString(message);

			try {
				__PrintAlertText(clientIndex, &__message);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__message);
			}
		}

		/// <summary>
		/// Prints a html message to a specific client in the center of the screen.
		/// </summary>
		/// <param name="clientIndex">Index of the client to whom the message will be sent.</param>
		/// <param name="message">The HTML-formatted message to be printed.</param>

		internal static delegate*<int, string, void> PrintCentreHtml = &___PrintCentreHtml;
		internal static delegate* unmanaged[Cdecl]<int, String192*, void> __PrintCentreHtml;
		private static void ___PrintCentreHtml(int clientIndex, string message)
		{
			var __message = NativeMethods.ConstructString(message);

			try {
				__PrintCentreHtml(clientIndex, &__message);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__message);
			}
		}

		/// <summary>
		/// Sends a message to every client's console.
		/// </summary>
		/// <param name="message">The message to be sent to all clients' consoles.</param>

		internal static delegate*<string, void> PrintToConsoleAll = &___PrintToConsoleAll;
		internal static delegate* unmanaged[Cdecl]<String192*, void> __PrintToConsoleAll;
		private static void ___PrintToConsoleAll(string message)
		{
			var __message = NativeMethods.ConstructString(message);

			try {
				__PrintToConsoleAll(&__message);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__message);
			}
		}

		/// <summary>
		/// Prints a message to all clients in the chat area.
		/// </summary>
		/// <param name="message">The message to be printed in the chat area for all clients.</param>

		internal static delegate*<string, void> PrintToChatAll = &___PrintToChatAll;
		internal static delegate* unmanaged[Cdecl]<String192*, void> __PrintToChatAll;
		private static void ___PrintToChatAll(string message)
		{
			var __message = NativeMethods.ConstructString(message);

			try {
				__PrintToChatAll(&__message);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__message);
			}
		}

		/// <summary>
		/// Prints a message to all clients in the center of the screen.
		/// </summary>
		/// <param name="message">The message to be printed in the center of the screen for all clients.</param>

		internal static delegate*<string, void> PrintCenterTextAll = &___PrintCenterTextAll;
		internal static delegate* unmanaged[Cdecl]<String192*, void> __PrintCenterTextAll;
		private static void ___PrintCenterTextAll(string message)
		{
			var __message = NativeMethods.ConstructString(message);

			try {
				__PrintCenterTextAll(&__message);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__message);
			}
		}

		/// <summary>
		/// Prints a message to all clients with an alert box.
		/// </summary>
		/// <param name="message">The message to be printed in an alert box for all clients.</param>

		internal static delegate*<string, void> PrintAlertTextAll = &___PrintAlertTextAll;
		internal static delegate* unmanaged[Cdecl]<String192*, void> __PrintAlertTextAll;
		private static void ___PrintAlertTextAll(string message)
		{
			var __message = NativeMethods.ConstructString(message);

			try {
				__PrintAlertTextAll(&__message);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__message);
			}
		}

		/// <summary>
		/// Prints a html message to all clients in the center of the screen.
		/// </summary>
		/// <param name="message">The HTML-formatted message to be printed in the center of the screen for all clients.</param>

		internal static delegate*<string, void> PrintCentreHtmlAll = &___PrintCentreHtmlAll;
		internal static delegate* unmanaged[Cdecl]<String192*, void> __PrintCentreHtmlAll;
		private static void ___PrintCentreHtmlAll(string message)
		{
			var __message = NativeMethods.ConstructString(message);

			try {
				__PrintCentreHtmlAll(&__message);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__message);
			}
		}

		/// <summary>
		/// Prints a colored message to a specific client in the chat area.
		/// </summary>
		/// <param name="clientIndex">Index of the client to whom the message will be sent.</param>
		/// <param name="message">The message to be printed in the chat area with color.</param>

		internal static delegate*<int, string, void> PrintToChatColored = &___PrintToChatColored;
		internal static delegate* unmanaged[Cdecl]<int, String192*, void> __PrintToChatColored;
		private static void ___PrintToChatColored(int clientIndex, string message)
		{
			var __message = NativeMethods.ConstructString(message);

			try {
				__PrintToChatColored(clientIndex, &__message);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__message);
			}
		}

		/// <summary>
		/// Prints a colored message to all clients in the chat area.
		/// </summary>
		/// <param name="message">The colored message to be printed in the chat area for all clients.</param>

		internal static delegate*<string, void> PrintToChatColoredAll = &___PrintToChatColoredAll;
		internal static delegate* unmanaged[Cdecl]<String192*, void> __PrintToChatColoredAll;
		private static void ___PrintToChatColoredAll(string message)
		{
			var __message = NativeMethods.ConstructString(message);

			try {
				__PrintToChatColoredAll(&__message);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__message);
			}
		}

		/// <summary>
		/// Creates a new console variable.
		/// </summary>
		/// <param name="name">The name of the console variable.</param>
		/// <param name="defaultValue">The default value of the console variable.</param>
		/// <param name="description">A description of the console variable's purpose.</param>
		/// <param name="flags">Additional flags for the console variable.</param>
		/// <returns>A pointer to the created console variable.</returns>

		internal static delegate*<string, string, string, int, nint> CreateConVar = &___CreateConVar;
		internal static delegate* unmanaged[Cdecl]<String192*, String192*, String192*, int, nint> __CreateConVar;
		private static nint ___CreateConVar(string name, string defaultValue, string description, int flags)
		{
			nint __retVal;
			var __name = NativeMethods.ConstructString(name);
			var __defaultValue = NativeMethods.ConstructString(defaultValue);
			var __description = NativeMethods.ConstructString(description);

			try {
				__retVal = __CreateConVar(&__name, &__defaultValue, &__description, flags);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
				NativeMethods.DestroyString(&__defaultValue);
				NativeMethods.DestroyString(&__description);
			}
			return __retVal;
		}

		/// <summary>
		/// Creates a new boolean console variable.
		/// </summary>
		/// <param name="name">The name of the console variable.</param>
		/// <param name="defaultValue">The default value for the console variable.</param>
		/// <param name="description">A brief description of the console variable.</param>
		/// <param name="flags">Flags that define the behavior of the console variable.</param>
		/// <param name="hasMin">Indicates if a minimum value is provided.</param>
		/// <param name="min">The minimum value if hasMin is true.</param>
		/// <param name="hasMax">Indicates if a maximum value is provided.</param>
		/// <param name="max">The maximum value if hasMax is true.</param>
		/// <returns>A pointer to the created console variable data.</returns>

		internal static delegate*<string, Bool8, string, int, Bool8, Bool8, Bool8, Bool8, nint> CreateConVarBool = &___CreateConVarBool;
		internal static delegate* unmanaged[Cdecl]<String192*, Bool8, String192*, int, Bool8, Bool8, Bool8, Bool8, nint> __CreateConVarBool;
		private static nint ___CreateConVarBool(string name, Bool8 defaultValue, string description, int flags, Bool8 hasMin, Bool8 min, Bool8 hasMax, Bool8 max)
		{
			nint __retVal;
			var __name = NativeMethods.ConstructString(name);
			var __description = NativeMethods.ConstructString(description);

			try {
				__retVal = __CreateConVarBool(&__name, defaultValue, &__description, flags, hasMin, min, hasMax, max);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
				NativeMethods.DestroyString(&__description);
			}
			return __retVal;
		}

		/// <summary>
		/// Creates a new 16-bit signed integer console variable.
		/// </summary>
		/// <param name="name">The name of the console variable.</param>
		/// <param name="defaultValue">The default value for the console variable.</param>
		/// <param name="description">A brief description of the console variable.</param>
		/// <param name="flags">Flags that define the behavior of the console variable.</param>
		/// <param name="hasMin">Indicates if a minimum value is provided.</param>
		/// <param name="min">The minimum value if hasMin is true.</param>
		/// <param name="hasMax">Indicates if a maximum value is provided.</param>
		/// <param name="max">The maximum value if hasMax is true.</param>
		/// <returns>A pointer to the created console variable data.</returns>

		internal static delegate*<string, short, string, int, Bool8, short, Bool8, short, nint> CreateConVarInt16 = &___CreateConVarInt16;
		internal static delegate* unmanaged[Cdecl]<String192*, short, String192*, int, Bool8, short, Bool8, short, nint> __CreateConVarInt16;
		private static nint ___CreateConVarInt16(string name, short defaultValue, string description, int flags, Bool8 hasMin, short min, Bool8 hasMax, short max)
		{
			nint __retVal;
			var __name = NativeMethods.ConstructString(name);
			var __description = NativeMethods.ConstructString(description);

			try {
				__retVal = __CreateConVarInt16(&__name, defaultValue, &__description, flags, hasMin, min, hasMax, max);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
				NativeMethods.DestroyString(&__description);
			}
			return __retVal;
		}

		/// <summary>
		/// Creates a new 16-bit unsigned integer console variable.
		/// </summary>
		/// <param name="name">The name of the console variable.</param>
		/// <param name="defaultValue">The default value for the console variable.</param>
		/// <param name="description">A brief description of the console variable.</param>
		/// <param name="flags">Flags that define the behavior of the console variable.</param>
		/// <param name="hasMin">Indicates if a minimum value is provided.</param>
		/// <param name="min">The minimum value if hasMin is true.</param>
		/// <param name="hasMax">Indicates if a maximum value is provided.</param>
		/// <param name="max">The maximum value if hasMax is true.</param>
		/// <returns>A pointer to the created console variable data.</returns>

		internal static delegate*<string, ushort, string, int, Bool8, ushort, Bool8, ushort, nint> CreateConVarUInt16 = &___CreateConVarUInt16;
		internal static delegate* unmanaged[Cdecl]<String192*, ushort, String192*, int, Bool8, ushort, Bool8, ushort, nint> __CreateConVarUInt16;
		private static nint ___CreateConVarUInt16(string name, ushort defaultValue, string description, int flags, Bool8 hasMin, ushort min, Bool8 hasMax, ushort max)
		{
			nint __retVal;
			var __name = NativeMethods.ConstructString(name);
			var __description = NativeMethods.ConstructString(description);

			try {
				__retVal = __CreateConVarUInt16(&__name, defaultValue, &__description, flags, hasMin, min, hasMax, max);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
				NativeMethods.DestroyString(&__description);
			}
			return __retVal;
		}

		/// <summary>
		/// Creates a new 32-bit signed integer console variable.
		/// </summary>
		/// <param name="name">The name of the console variable.</param>
		/// <param name="defaultValue">The default value for the console variable.</param>
		/// <param name="description">A brief description of the console variable.</param>
		/// <param name="flags">Flags that define the behavior of the console variable.</param>
		/// <param name="hasMin">Indicates if a minimum value is provided.</param>
		/// <param name="min">The minimum value if hasMin is true.</param>
		/// <param name="hasMax">Indicates if a maximum value is provided.</param>
		/// <param name="max">The maximum value if hasMax is true.</param>
		/// <returns>A pointer to the created console variable data.</returns>

		internal static delegate*<string, int, string, int, Bool8, int, Bool8, int, nint> CreateConVarInt32 = &___CreateConVarInt32;
		internal static delegate* unmanaged[Cdecl]<String192*, int, String192*, int, Bool8, int, Bool8, int, nint> __CreateConVarInt32;
		private static nint ___CreateConVarInt32(string name, int defaultValue, string description, int flags, Bool8 hasMin, int min, Bool8 hasMax, int max)
		{
			nint __retVal;
			var __name = NativeMethods.ConstructString(name);
			var __description = NativeMethods.ConstructString(description);

			try {
				__retVal = __CreateConVarInt32(&__name, defaultValue, &__description, flags, hasMin, min, hasMax, max);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
				NativeMethods.DestroyString(&__description);
			}
			return __retVal;
		}

		/// <summary>
		/// Creates a new 32-bit unsigned integer console variable.
		/// </summary>
		/// <param name="name">The name of the console variable.</param>
		/// <param name="defaultValue">The default value for the console variable.</param>
		/// <param name="description">A brief description of the console variable.</param>
		/// <param name="flags">Flags that define the behavior of the console variable.</param>
		/// <param name="hasMin">Indicates if a minimum value is provided.</param>
		/// <param name="min">The minimum value if hasMin is true.</param>
		/// <param name="hasMax">Indicates if a maximum value is provided.</param>
		/// <param name="max">The maximum value if hasMax is true.</param>
		/// <returns>A pointer to the created console variable data.</returns>

		internal static delegate*<string, uint, string, int, Bool8, uint, Bool8, uint, nint> CreateConVarUInt32 = &___CreateConVarUInt32;
		internal static delegate* unmanaged[Cdecl]<String192*, uint, String192*, int, Bool8, uint, Bool8, uint, nint> __CreateConVarUInt32;
		private static nint ___CreateConVarUInt32(string name, uint defaultValue, string description, int flags, Bool8 hasMin, uint min, Bool8 hasMax, uint max)
		{
			nint __retVal;
			var __name = NativeMethods.ConstructString(name);
			var __description = NativeMethods.ConstructString(description);

			try {
				__retVal = __CreateConVarUInt32(&__name, defaultValue, &__description, flags, hasMin, min, hasMax, max);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
				NativeMethods.DestroyString(&__description);
			}
			return __retVal;
		}

		/// <summary>
		/// Creates a new 64-bit signed integer console variable.
		/// </summary>
		/// <param name="name">The name of the console variable.</param>
		/// <param name="defaultValue">The default value for the console variable.</param>
		/// <param name="description">A brief description of the console variable.</param>
		/// <param name="flags">Flags that define the behavior of the console variable.</param>
		/// <param name="hasMin">Indicates if a minimum value is provided.</param>
		/// <param name="min">The minimum value if hasMin is true.</param>
		/// <param name="hasMax">Indicates if a maximum value is provided.</param>
		/// <param name="max">The maximum value if hasMax is true.</param>
		/// <returns>A pointer to the created console variable data.</returns>

		internal static delegate*<string, long, string, int, Bool8, long, Bool8, long, nint> CreateConVarInt64 = &___CreateConVarInt64;
		internal static delegate* unmanaged[Cdecl]<String192*, long, String192*, int, Bool8, long, Bool8, long, nint> __CreateConVarInt64;
		private static nint ___CreateConVarInt64(string name, long defaultValue, string description, int flags, Bool8 hasMin, long min, Bool8 hasMax, long max)
		{
			nint __retVal;
			var __name = NativeMethods.ConstructString(name);
			var __description = NativeMethods.ConstructString(description);

			try {
				__retVal = __CreateConVarInt64(&__name, defaultValue, &__description, flags, hasMin, min, hasMax, max);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
				NativeMethods.DestroyString(&__description);
			}
			return __retVal;
		}

		/// <summary>
		/// Creates a new 64-bit unsigned integer console variable.
		/// </summary>
		/// <param name="name">The name of the console variable.</param>
		/// <param name="defaultValue">The default value for the console variable.</param>
		/// <param name="description">A brief description of the console variable.</param>
		/// <param name="flags">Flags that define the behavior of the console variable.</param>
		/// <param name="hasMin">Indicates if a minimum value is provided.</param>
		/// <param name="min">The minimum value if hasMin is true.</param>
		/// <param name="hasMax">Indicates if a maximum value is provided.</param>
		/// <param name="max">The maximum value if hasMax is true.</param>
		/// <returns>A pointer to the created console variable data.</returns>

		internal static delegate*<string, ulong, string, int, Bool8, ulong, Bool8, ulong, nint> CreateConVarUInt64 = &___CreateConVarUInt64;
		internal static delegate* unmanaged[Cdecl]<String192*, ulong, String192*, int, Bool8, ulong, Bool8, ulong, nint> __CreateConVarUInt64;
		private static nint ___CreateConVarUInt64(string name, ulong defaultValue, string description, int flags, Bool8 hasMin, ulong min, Bool8 hasMax, ulong max)
		{
			nint __retVal;
			var __name = NativeMethods.ConstructString(name);
			var __description = NativeMethods.ConstructString(description);

			try {
				__retVal = __CreateConVarUInt64(&__name, defaultValue, &__description, flags, hasMin, min, hasMax, max);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
				NativeMethods.DestroyString(&__description);
			}
			return __retVal;
		}

		/// <summary>
		/// Creates a new floating-point console variable.
		/// </summary>
		/// <param name="name">The name of the console variable.</param>
		/// <param name="defaultValue">The default value for the console variable.</param>
		/// <param name="description">A brief description of the console variable.</param>
		/// <param name="flags">Flags that define the behavior of the console variable.</param>
		/// <param name="hasMin">Indicates if a minimum value is provided.</param>
		/// <param name="min">The minimum value if hasMin is true.</param>
		/// <param name="hasMax">Indicates if a maximum value is provided.</param>
		/// <param name="max">The maximum value if hasMax is true.</param>
		/// <returns>A pointer to the created console variable data.</returns>

		internal static delegate*<string, float, string, int, Bool8, float, Bool8, float, nint> CreateConVarFloat = &___CreateConVarFloat;
		internal static delegate* unmanaged[Cdecl]<String192*, float, String192*, int, Bool8, float, Bool8, float, nint> __CreateConVarFloat;
		private static nint ___CreateConVarFloat(string name, float defaultValue, string description, int flags, Bool8 hasMin, float min, Bool8 hasMax, float max)
		{
			nint __retVal;
			var __name = NativeMethods.ConstructString(name);
			var __description = NativeMethods.ConstructString(description);

			try {
				__retVal = __CreateConVarFloat(&__name, defaultValue, &__description, flags, hasMin, min, hasMax, max);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
				NativeMethods.DestroyString(&__description);
			}
			return __retVal;
		}

		/// <summary>
		/// Creates a new double-precision console variable.
		/// </summary>
		/// <param name="name">The name of the console variable.</param>
		/// <param name="defaultValue">The default value for the console variable.</param>
		/// <param name="description">A brief description of the console variable.</param>
		/// <param name="flags">Flags that define the behavior of the console variable.</param>
		/// <param name="hasMin">Indicates if a minimum value is provided.</param>
		/// <param name="min">The minimum value if hasMin is true.</param>
		/// <param name="hasMax">Indicates if a maximum value is provided.</param>
		/// <param name="max">The maximum value if hasMax is true.</param>
		/// <returns>A pointer to the created console variable data.</returns>

		internal static delegate*<string, double, string, int, Bool8, double, Bool8, double, nint> CreateConVarDouble = &___CreateConVarDouble;
		internal static delegate* unmanaged[Cdecl]<String192*, double, String192*, int, Bool8, double, Bool8, double, nint> __CreateConVarDouble;
		private static nint ___CreateConVarDouble(string name, double defaultValue, string description, int flags, Bool8 hasMin, double min, Bool8 hasMax, double max)
		{
			nint __retVal;
			var __name = NativeMethods.ConstructString(name);
			var __description = NativeMethods.ConstructString(description);

			try {
				__retVal = __CreateConVarDouble(&__name, defaultValue, &__description, flags, hasMin, min, hasMax, max);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
				NativeMethods.DestroyString(&__description);
			}
			return __retVal;
		}

		/// <summary>
		/// Creates a new color console variable.
		/// </summary>
		/// <param name="name">The name of the console variable.</param>
		/// <param name="defaultValue">The default color value for the console variable.</param>
		/// <param name="description">A brief description of the console variable.</param>
		/// <param name="flags">Flags that define the behavior of the console variable.</param>
		/// <param name="hasMin">Indicates if a minimum value is provided.</param>
		/// <param name="min">The minimum color value if hasMin is true.</param>
		/// <param name="hasMax">Indicates if a maximum value is provided.</param>
		/// <param name="max">The maximum color value if hasMax is true.</param>
		/// <returns>A pointer to the created console variable data.</returns>

		internal static delegate*<string, int, string, int, Bool8, int, Bool8, int, nint> CreateConVarColor = &___CreateConVarColor;
		internal static delegate* unmanaged[Cdecl]<String192*, int, String192*, int, Bool8, int, Bool8, int, nint> __CreateConVarColor;
		private static nint ___CreateConVarColor(string name, int defaultValue, string description, int flags, Bool8 hasMin, int min, Bool8 hasMax, int max)
		{
			nint __retVal;
			var __name = NativeMethods.ConstructString(name);
			var __description = NativeMethods.ConstructString(description);

			try {
				__retVal = __CreateConVarColor(&__name, defaultValue, &__description, flags, hasMin, min, hasMax, max);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
				NativeMethods.DestroyString(&__description);
			}
			return __retVal;
		}

		/// <summary>
		/// Creates a new 2D vector console variable.
		/// </summary>
		/// <param name="name">The name of the console variable.</param>
		/// <param name="defaultValue">The default value for the console variable.</param>
		/// <param name="description">A brief description of the console variable.</param>
		/// <param name="flags">Flags that define the behavior of the console variable.</param>
		/// <param name="hasMin">Indicates if a minimum value is provided.</param>
		/// <param name="min">The minimum value if hasMin is true.</param>
		/// <param name="hasMax">Indicates if a maximum value is provided.</param>
		/// <param name="max">The maximum value if hasMax is true.</param>
		/// <returns>A pointer to the created console variable data.</returns>

		internal static delegate*<string, Vector2, string, int, Bool8, Vector2, Bool8, Vector2, nint> CreateConVarVector2 = &___CreateConVarVector2;
		internal static delegate* unmanaged[Cdecl]<String192*, Vector2*, String192*, int, Bool8, Vector2*, Bool8, Vector2*, nint> __CreateConVarVector2;
		private static nint ___CreateConVarVector2(string name, Vector2 defaultValue, string description, int flags, Bool8 hasMin, Vector2 min, Bool8 hasMax, Vector2 max)
		{
			nint __retVal;
			var __name = NativeMethods.ConstructString(name);
			var __description = NativeMethods.ConstructString(description);

			try {
				__retVal = __CreateConVarVector2(&__name, &defaultValue, &__description, flags, hasMin, &min, hasMax, &max);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
				NativeMethods.DestroyString(&__description);
			}
			return __retVal;
		}

		/// <summary>
		/// Creates a new 3D vector console variable.
		/// </summary>
		/// <param name="name">The name of the console variable.</param>
		/// <param name="defaultValue">The default value for the console variable.</param>
		/// <param name="description">A brief description of the console variable.</param>
		/// <param name="flags">Flags that define the behavior of the console variable.</param>
		/// <param name="hasMin">Indicates if a minimum value is provided.</param>
		/// <param name="min">The minimum value if hasMin is true.</param>
		/// <param name="hasMax">Indicates if a maximum value is provided.</param>
		/// <param name="max">The maximum value if hasMax is true.</param>
		/// <returns>A pointer to the created console variable data.</returns>

		internal static delegate*<string, Vector3, string, int, Bool8, Vector3, Bool8, Vector3, nint> CreateConVarVector3 = &___CreateConVarVector3;
		internal static delegate* unmanaged[Cdecl]<String192*, Vector3*, String192*, int, Bool8, Vector3*, Bool8, Vector3*, nint> __CreateConVarVector3;
		private static nint ___CreateConVarVector3(string name, Vector3 defaultValue, string description, int flags, Bool8 hasMin, Vector3 min, Bool8 hasMax, Vector3 max)
		{
			nint __retVal;
			var __name = NativeMethods.ConstructString(name);
			var __description = NativeMethods.ConstructString(description);

			try {
				__retVal = __CreateConVarVector3(&__name, &defaultValue, &__description, flags, hasMin, &min, hasMax, &max);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
				NativeMethods.DestroyString(&__description);
			}
			return __retVal;
		}

		/// <summary>
		/// Creates a new 4D vector console variable.
		/// </summary>
		/// <param name="name">The name of the console variable.</param>
		/// <param name="defaultValue">The default value for the console variable.</param>
		/// <param name="description">A brief description of the console variable.</param>
		/// <param name="flags">Flags that define the behavior of the console variable.</param>
		/// <param name="hasMin">Indicates if a minimum value is provided.</param>
		/// <param name="min">The minimum value if hasMin is true.</param>
		/// <param name="hasMax">Indicates if a maximum value is provided.</param>
		/// <param name="max">The maximum value if hasMax is true.</param>
		/// <returns>A pointer to the created console variable data.</returns>

		internal static delegate*<string, Vector4, string, int, Bool8, Vector4, Bool8, Vector4, nint> CreateConVarVector4 = &___CreateConVarVector4;
		internal static delegate* unmanaged[Cdecl]<String192*, Vector4*, String192*, int, Bool8, Vector4*, Bool8, Vector4*, nint> __CreateConVarVector4;
		private static nint ___CreateConVarVector4(string name, Vector4 defaultValue, string description, int flags, Bool8 hasMin, Vector4 min, Bool8 hasMax, Vector4 max)
		{
			nint __retVal;
			var __name = NativeMethods.ConstructString(name);
			var __description = NativeMethods.ConstructString(description);

			try {
				__retVal = __CreateConVarVector4(&__name, &defaultValue, &__description, flags, hasMin, &min, hasMax, &max);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
				NativeMethods.DestroyString(&__description);
			}
			return __retVal;
		}

		/// <summary>
		/// Creates a new quaternion angle console variable.
		/// </summary>
		/// <param name="name">The name of the console variable.</param>
		/// <param name="defaultValue">The default value for the console variable.</param>
		/// <param name="description">A brief description of the console variable.</param>
		/// <param name="flags">Flags that define the behavior of the console variable.</param>
		/// <param name="hasMin">Indicates if a minimum value is provided.</param>
		/// <param name="min">The minimum value if hasMin is true.</param>
		/// <param name="hasMax">Indicates if a maximum value is provided.</param>
		/// <param name="max">The maximum value if hasMax is true.</param>
		/// <returns>A pointer to the created console variable data.</returns>

		internal static delegate*<string, Vector3, string, int, Bool8, Vector3, Bool8, Vector3, nint> CreateConVarQAngle = &___CreateConVarQAngle;
		internal static delegate* unmanaged[Cdecl]<String192*, Vector3*, String192*, int, Bool8, Vector3*, Bool8, Vector3*, nint> __CreateConVarQAngle;
		private static nint ___CreateConVarQAngle(string name, Vector3 defaultValue, string description, int flags, Bool8 hasMin, Vector3 min, Bool8 hasMax, Vector3 max)
		{
			nint __retVal;
			var __name = NativeMethods.ConstructString(name);
			var __description = NativeMethods.ConstructString(description);

			try {
				__retVal = __CreateConVarQAngle(&__name, &defaultValue, &__description, flags, hasMin, &min, hasMax, &max);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
				NativeMethods.DestroyString(&__description);
			}
			return __retVal;
		}

		/// <summary>
		/// Searches for a console variable.
		/// </summary>
		/// <param name="name">The name of the console variable to search for.</param>
		/// <returns>Pointer to the console variable data if found; otherwise, nullptr.</returns>

		internal static delegate*<string, nint> FindConVar = &___FindConVar;
		internal static delegate* unmanaged[Cdecl]<String192*, nint> __FindConVar;
		private static nint ___FindConVar(string name)
		{
			nint __retVal;
			var __name = NativeMethods.ConstructString(name);

			try {
				__retVal = __FindConVar(&__name);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
			}
			return __retVal;
		}

		/// <summary>
		/// Creates a hook for when a console variable's value is changed.
		/// </summary>
		/// <param name="name">The name of the console variable to hook.</param>
		/// <param name="callback">The callback function to be executed when the variable's value changes.</param>
		/// <remarks>
		/// Callback ChangeCallback: Handles changes to a console variable's value. This function is called whenever the value of a specific console variable is modified.
		/// - Parameter pConVar: A 64-bit pointer to the console variable that is being changed. This provides access to the variable's metadata and current state.
		/// - Parameter newValue: The new value being assigned to the console variable. This string contains the updated value after the change.
		/// - Parameter oldValue: The previous value of the console variable before the change. This string contains the value that was overridden.
		/// - Returns: This function does not return a value. It performs any necessary processing related to the value change directly. (void)
		/// </remarks>

		internal static delegate*<string, ChangeCallback, void> HookConVarChange = &___HookConVarChange;
		internal static delegate* unmanaged[Cdecl]<String192*, nint, void> __HookConVarChange;
		private static void ___HookConVarChange(string name, ChangeCallback callback)
		{
			var __name = NativeMethods.ConstructString(name);
			var __callback = Marshalling.GetFunctionPointerForDelegate(callback);

			try {
				__HookConVarChange(&__name, __callback);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
			}
		}

		/// <summary>
		/// Removes a hook for when a console variable's value is changed.
		/// </summary>
		/// <param name="name">The name of the console variable to unhook.</param>
		/// <param name="callback">The callback function to be removed.</param>
		/// <remarks>
		/// Callback ChangeCallback: Handles changes to a console variable's value. This function is called whenever the value of a specific console variable is modified.
		/// - Parameter pConVar: A 64-bit pointer to the console variable that is being changed. This provides access to the variable's metadata and current state.
		/// - Parameter newValue: The new value being assigned to the console variable. This string contains the updated value after the change.
		/// - Parameter oldValue: The previous value of the console variable before the change. This string contains the value that was overridden.
		/// - Returns: This function does not return a value. It performs any necessary processing related to the value change directly. (void)
		/// </remarks>

		internal static delegate*<string, ChangeCallback, void> UnhookConVarChange = &___UnhookConVarChange;
		internal static delegate* unmanaged[Cdecl]<String192*, nint, void> __UnhookConVarChange;
		private static void ___UnhookConVarChange(string name, ChangeCallback callback)
		{
			var __name = NativeMethods.ConstructString(name);
			var __callback = Marshalling.GetFunctionPointerForDelegate(callback);

			try {
				__UnhookConVarChange(&__name, __callback);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
			}
		}

		/// <summary>
		/// Checks if a specific flag is set for a console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="flag">The flag to check against the console variable.</param>
		/// <returns>True if the flag is set; otherwise, false.</returns>

		internal static delegate*<nint, long, Bool8> IsConVarFlagSet = &___IsConVarFlagSet;
		internal static delegate* unmanaged[Cdecl]<nint, long, Bool8> __IsConVarFlagSet;
		private static Bool8 ___IsConVarFlagSet(nint conVar, long flag)
		{
			Bool8 __retVal = __IsConVarFlagSet(conVar, flag);
			return __retVal;
		}

		/// <summary>
		/// Adds flags to a console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="flags">The flags to be added.</param>

		internal static delegate*<nint, long, void> AddConVarFlags = &___AddConVarFlags;
		internal static delegate* unmanaged[Cdecl]<nint, long, void> __AddConVarFlags;
		private static void ___AddConVarFlags(nint conVar, long flags)
		{
			__AddConVarFlags(conVar, flags);
		}

		/// <summary>
		/// Removes flags from a console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="flags">The flags to be removed.</param>

		internal static delegate*<nint, long, void> RemoveConVarFlags = &___RemoveConVarFlags;
		internal static delegate* unmanaged[Cdecl]<nint, long, void> __RemoveConVarFlags;
		private static void ___RemoveConVarFlags(nint conVar, long flags)
		{
			__RemoveConVarFlags(conVar, flags);
		}

		/// <summary>
		/// Retrieves the current flags of a console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <returns>The current flags set on the console variable.</returns>

		internal static delegate*<nint, long> GetConVarFlags = &___GetConVarFlags;
		internal static delegate* unmanaged[Cdecl]<nint, long> __GetConVarFlags;
		private static long ___GetConVarFlags(nint conVar)
		{
			long __retVal = __GetConVarFlags(conVar);
			return __retVal;
		}

		/// <summary>
		/// Gets the specified bound (max or min) of a console variable and stores it in the output string.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="max">Indicates whether to get the maximum (true) or minimum (false) bound.</param>
		/// <returns>The bound value.</returns>

		internal static delegate*<nint, Bool8, string> GetConVarBounds = &___GetConVarBounds;
		internal static delegate* unmanaged[Cdecl]<nint, Bool8, String192> __GetConVarBounds;
		private static string ___GetConVarBounds(nint conVar, Bool8 max)
		{
			string __retVal;
			String192 __retVal_native;

			try {
				__retVal_native = __GetConVarBounds(conVar, max);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
			}
			return __retVal;
		}

		/// <summary>
		/// Sets the specified bound (max or min) for a console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="max">Indicates whether to set the maximum (true) or minimum (false) bound.</param>
		/// <param name="value">The value to set as the bound.</param>

		internal static delegate*<nint, Bool8, string, void> SetConVarBounds = &___SetConVarBounds;
		internal static delegate* unmanaged[Cdecl]<nint, Bool8, String192*, void> __SetConVarBounds;
		private static void ___SetConVarBounds(nint conVar, Bool8 max, string value)
		{
			var __value = NativeMethods.ConstructString(value);

			try {
				__SetConVarBounds(conVar, max, &__value);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__value);
			}
		}

		/// <summary>
		/// Retrieves the default value of a console variable and stores it in the output string.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <returns>The output value in string format.</returns>

		internal static delegate*<nint, string> GetConVarDefault = &___GetConVarDefault;
		internal static delegate* unmanaged[Cdecl]<nint, String192> __GetConVarDefault;
		private static string ___GetConVarDefault(nint conVar)
		{
			string __retVal;
			String192 __retVal_native;

			try {
				__retVal_native = __GetConVarDefault(conVar);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the current value of a console variable and stores it in the output string.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <returns>The output value in string format.</returns>

		internal static delegate*<nint, string> GetConVarValue = &___GetConVarValue;
		internal static delegate* unmanaged[Cdecl]<nint, String192> __GetConVarValue;
		private static string ___GetConVarValue(nint conVar)
		{
			string __retVal;
			String192 __retVal_native;

			try {
				__retVal_native = __GetConVarValue(conVar);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the current value of a console variable and stores it in the output.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <returns>The output value.</returns>

		internal static delegate*<nint, object?> GetConVar = &___GetConVar;
		internal static delegate* unmanaged[Cdecl]<nint, Variant256> __GetConVar;
		private static object? ___GetConVar(nint conVar)
		{
			object? __retVal;
			Variant256 __retVal_native;

			try {
				__retVal_native = __GetConVar(conVar);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetVariantData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyVariant(&__retVal_native);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the current value of a boolean console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <returns>The current boolean value of the console variable.</returns>

		internal static delegate*<nint, Bool8> GetConVarBool = &___GetConVarBool;
		internal static delegate* unmanaged[Cdecl]<nint, Bool8> __GetConVarBool;
		private static Bool8 ___GetConVarBool(nint conVar)
		{
			Bool8 __retVal = __GetConVarBool(conVar);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the current value of a signed 16-bit integer console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <returns>The current int16_t value of the console variable.</returns>

		internal static delegate*<nint, short> GetConVarInt16 = &___GetConVarInt16;
		internal static delegate* unmanaged[Cdecl]<nint, short> __GetConVarInt16;
		private static short ___GetConVarInt16(nint conVar)
		{
			short __retVal = __GetConVarInt16(conVar);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the current value of an unsigned 16-bit integer console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <returns>The current uint16_t value of the console variable.</returns>

		internal static delegate*<nint, ushort> GetConVarUInt16 = &___GetConVarUInt16;
		internal static delegate* unmanaged[Cdecl]<nint, ushort> __GetConVarUInt16;
		private static ushort ___GetConVarUInt16(nint conVar)
		{
			ushort __retVal = __GetConVarUInt16(conVar);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the current value of a signed 32-bit integer console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <returns>The current int32_t value of the console variable.</returns>

		internal static delegate*<nint, int> GetConVarInt32 = &___GetConVarInt32;
		internal static delegate* unmanaged[Cdecl]<nint, int> __GetConVarInt32;
		private static int ___GetConVarInt32(nint conVar)
		{
			int __retVal = __GetConVarInt32(conVar);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the current value of an unsigned 32-bit integer console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <returns>The current uint32_t value of the console variable.</returns>

		internal static delegate*<nint, uint> GetConVarUInt32 = &___GetConVarUInt32;
		internal static delegate* unmanaged[Cdecl]<nint, uint> __GetConVarUInt32;
		private static uint ___GetConVarUInt32(nint conVar)
		{
			uint __retVal = __GetConVarUInt32(conVar);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the current value of a signed 64-bit integer console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <returns>The current int64_t value of the console variable.</returns>

		internal static delegate*<nint, long> GetConVarInt64 = &___GetConVarInt64;
		internal static delegate* unmanaged[Cdecl]<nint, long> __GetConVarInt64;
		private static long ___GetConVarInt64(nint conVar)
		{
			long __retVal = __GetConVarInt64(conVar);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the current value of an unsigned 64-bit integer console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <returns>The current uint64_t value of the console variable.</returns>

		internal static delegate*<nint, ulong> GetConVarUInt64 = &___GetConVarUInt64;
		internal static delegate* unmanaged[Cdecl]<nint, ulong> __GetConVarUInt64;
		private static ulong ___GetConVarUInt64(nint conVar)
		{
			ulong __retVal = __GetConVarUInt64(conVar);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the current value of a float console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <returns>The current float value of the console variable.</returns>

		internal static delegate*<nint, float> GetConVarFloat = &___GetConVarFloat;
		internal static delegate* unmanaged[Cdecl]<nint, float> __GetConVarFloat;
		private static float ___GetConVarFloat(nint conVar)
		{
			float __retVal = __GetConVarFloat(conVar);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the current value of a double console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <returns>The current double value of the console variable.</returns>

		internal static delegate*<nint, double> GetConVarDouble = &___GetConVarDouble;
		internal static delegate* unmanaged[Cdecl]<nint, double> __GetConVarDouble;
		private static double ___GetConVarDouble(nint conVar)
		{
			double __retVal = __GetConVarDouble(conVar);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the current value of a string console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <returns>The current string value of the console variable.</returns>

		internal static delegate*<nint, string> GetConVarString = &___GetConVarString;
		internal static delegate* unmanaged[Cdecl]<nint, String192> __GetConVarString;
		private static string ___GetConVarString(nint conVar)
		{
			string __retVal;
			String192 __retVal_native;

			try {
				__retVal_native = __GetConVarString(conVar);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the current value of a Color console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <returns>The current Color value of the console variable.</returns>

		internal static delegate*<nint, int> GetConVarColor = &___GetConVarColor;
		internal static delegate* unmanaged[Cdecl]<nint, int> __GetConVarColor;
		private static int ___GetConVarColor(nint conVar)
		{
			int __retVal = __GetConVarColor(conVar);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the current value of a Vector2D console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <returns>The current Vector2D value of the console variable.</returns>

		internal static delegate*<nint, Vector2> GetConVarVector2 = &___GetConVarVector2;
		internal static delegate* unmanaged[Cdecl]<nint, Vector2> __GetConVarVector2;
		private static Vector2 ___GetConVarVector2(nint conVar)
		{
			Vector2 __retVal = __GetConVarVector2(conVar);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the current value of a Vector console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <returns>The current Vector value of the console variable.</returns>

		internal static delegate*<nint, Vector3> GetConVarVector = &___GetConVarVector;
		internal static delegate* unmanaged[Cdecl]<nint, Vector3> __GetConVarVector;
		private static Vector3 ___GetConVarVector(nint conVar)
		{
			Vector3 __retVal = __GetConVarVector(conVar);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the current value of a Vector4D console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <returns>The current Vector4D value of the console variable.</returns>

		internal static delegate*<nint, Vector4> GetConVarVector4 = &___GetConVarVector4;
		internal static delegate* unmanaged[Cdecl]<nint, Vector4> __GetConVarVector4;
		private static Vector4 ___GetConVarVector4(nint conVar)
		{
			Vector4 __retVal = __GetConVarVector4(conVar);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the current value of a QAngle console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <returns>The current QAngle value of the console variable.</returns>

		internal static delegate*<nint, Vector3> GetConVarQAngle = &___GetConVarQAngle;
		internal static delegate* unmanaged[Cdecl]<nint, Vector3> __GetConVarQAngle;
		private static Vector3 ___GetConVarQAngle(nint conVar)
		{
			Vector3 __retVal = __GetConVarQAngle(conVar);
			return __retVal;
		}

		/// <summary>
		/// Sets the value of a console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="value">The string value to set for the console variable.</param>
		/// <param name="replicate">If set to true, the new convar value will be set on all clients. This will only work if the convar has the FCVAR_REPLICATED flag and actually exists on clients.</param>
		/// <param name="notify">If set to true, clients will be notified that the convar has changed. This will only work if the convar has the FCVAR_NOTIFY flag.</param>

		internal static delegate*<nint, string, Bool8, Bool8, void> SetConVarValue = &___SetConVarValue;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, Bool8, Bool8, void> __SetConVarValue;
		private static void ___SetConVarValue(nint conVar, string value, Bool8 replicate, Bool8 notify)
		{
			var __value = NativeMethods.ConstructString(value);

			try {
				__SetConVarValue(conVar, &__value, replicate, notify);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__value);
			}
		}

		/// <summary>
		/// Sets the value of a console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="value">The value to set for the console variable.</param>
		/// <param name="replicate">If set to true, the new convar value will be set on all clients. This will only work if the convar has the FCVAR_REPLICATED flag and actually exists on clients.</param>
		/// <param name="notify">If set to true, clients will be notified that the convar has changed. This will only work if the convar has the FCVAR_NOTIFY flag.</param>

		internal static delegate*<nint, object?, Bool8, Bool8, void> SetConVar = &___SetConVar;
		internal static delegate* unmanaged[Cdecl]<nint, Variant256*, Bool8, Bool8, void> __SetConVar;
		private static void ___SetConVar(nint conVar, object? value, Bool8 replicate, Bool8 notify)
		{
			var __value = NativeMethods.ConstructVariant(value);

			try {
				__SetConVar(conVar, &__value, replicate, notify);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyVariant(&__value);
			}
		}

		/// <summary>
		/// Sets the value of a boolean console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="value">The value to set for the console variable.</param>
		/// <param name="replicate">If set to true, the new convar value will be set on all clients. This will only work if the convar has the FCVAR_REPLICATED flag and actually exists on clients.</param>
		/// <param name="notify">If set to true, clients will be notified that the convar has changed. This will only work if the convar has the FCVAR_NOTIFY flag.</param>

		internal static delegate*<nint, Bool8, Bool8, Bool8, void> SetConVarBool = &___SetConVarBool;
		internal static delegate* unmanaged[Cdecl]<nint, Bool8, Bool8, Bool8, void> __SetConVarBool;
		private static void ___SetConVarBool(nint conVar, Bool8 value, Bool8 replicate, Bool8 notify)
		{
			__SetConVarBool(conVar, value, replicate, notify);
		}

		/// <summary>
		/// Sets the value of a signed 16-bit integer console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="value">The value to set for the console variable.</param>
		/// <param name="replicate">If set to true, the new convar value will be set on all clients. This will only work if the convar has the FCVAR_REPLICATED flag and actually exists on clients.</param>
		/// <param name="notify">If set to true, clients will be notified that the convar has changed. This will only work if the convar has the FCVAR_NOTIFY flag.</param>

		internal static delegate*<nint, short, Bool8, Bool8, void> SetConVarInt16 = &___SetConVarInt16;
		internal static delegate* unmanaged[Cdecl]<nint, short, Bool8, Bool8, void> __SetConVarInt16;
		private static void ___SetConVarInt16(nint conVar, short value, Bool8 replicate, Bool8 notify)
		{
			__SetConVarInt16(conVar, value, replicate, notify);
		}

		/// <summary>
		/// Sets the value of an unsigned 16-bit integer console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="value">The value to set for the console variable.</param>
		/// <param name="replicate">If set to true, the new convar value will be set on all clients. This will only work if the convar has the FCVAR_REPLICATED flag and actually exists on clients.</param>
		/// <param name="notify">If set to true, clients will be notified that the convar has changed. This will only work if the convar has the FCVAR_NOTIFY flag.</param>

		internal static delegate*<nint, ushort, Bool8, Bool8, void> SetConVarUInt16 = &___SetConVarUInt16;
		internal static delegate* unmanaged[Cdecl]<nint, ushort, Bool8, Bool8, void> __SetConVarUInt16;
		private static void ___SetConVarUInt16(nint conVar, ushort value, Bool8 replicate, Bool8 notify)
		{
			__SetConVarUInt16(conVar, value, replicate, notify);
		}

		/// <summary>
		/// Sets the value of a signed 32-bit integer console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="value">The value to set for the console variable.</param>
		/// <param name="replicate">If set to true, the new convar value will be set on all clients. This will only work if the convar has the FCVAR_REPLICATED flag and actually exists on clients.</param>
		/// <param name="notify">If set to true, clients will be notified that the convar has changed. This will only work if the convar has the FCVAR_NOTIFY flag.</param>

		internal static delegate*<nint, int, Bool8, Bool8, void> SetConVarInt32 = &___SetConVarInt32;
		internal static delegate* unmanaged[Cdecl]<nint, int, Bool8, Bool8, void> __SetConVarInt32;
		private static void ___SetConVarInt32(nint conVar, int value, Bool8 replicate, Bool8 notify)
		{
			__SetConVarInt32(conVar, value, replicate, notify);
		}

		/// <summary>
		/// Sets the value of an unsigned 32-bit integer console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="value">The value to set for the console variable.</param>
		/// <param name="replicate">If set to true, the new convar value will be set on all clients. This will only work if the convar has the FCVAR_REPLICATED flag and actually exists on clients.</param>
		/// <param name="notify">If set to true, clients will be notified that the convar has changed. This will only work if the convar has the FCVAR_NOTIFY flag.</param>

		internal static delegate*<nint, uint, Bool8, Bool8, void> SetConVarUInt32 = &___SetConVarUInt32;
		internal static delegate* unmanaged[Cdecl]<nint, uint, Bool8, Bool8, void> __SetConVarUInt32;
		private static void ___SetConVarUInt32(nint conVar, uint value, Bool8 replicate, Bool8 notify)
		{
			__SetConVarUInt32(conVar, value, replicate, notify);
		}

		/// <summary>
		/// Sets the value of a signed 64-bit integer console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="value">The value to set for the console variable.</param>
		/// <param name="replicate">If set to true, the new convar value will be set on all clients. This will only work if the convar has the FCVAR_REPLICATED flag and actually exists on clients.</param>
		/// <param name="notify">If set to true, clients will be notified that the convar has changed. This will only work if the convar has the FCVAR_NOTIFY flag.</param>

		internal static delegate*<nint, long, Bool8, Bool8, void> SetConVarInt64 = &___SetConVarInt64;
		internal static delegate* unmanaged[Cdecl]<nint, long, Bool8, Bool8, void> __SetConVarInt64;
		private static void ___SetConVarInt64(nint conVar, long value, Bool8 replicate, Bool8 notify)
		{
			__SetConVarInt64(conVar, value, replicate, notify);
		}

		/// <summary>
		/// Sets the value of an unsigned 64-bit integer console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="value">The value to set for the console variable.</param>
		/// <param name="replicate">If set to true, the new convar value will be set on all clients. This will only work if the convar has the FCVAR_REPLICATED flag and actually exists on clients.</param>
		/// <param name="notify">If set to true, clients will be notified that the convar has changed. This will only work if the convar has the FCVAR_NOTIFY flag.</param>

		internal static delegate*<nint, ulong, Bool8, Bool8, void> SetConVarUInt64 = &___SetConVarUInt64;
		internal static delegate* unmanaged[Cdecl]<nint, ulong, Bool8, Bool8, void> __SetConVarUInt64;
		private static void ___SetConVarUInt64(nint conVar, ulong value, Bool8 replicate, Bool8 notify)
		{
			__SetConVarUInt64(conVar, value, replicate, notify);
		}

		/// <summary>
		/// Sets the value of a floating-point console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="value">The value to set for the console variable.</param>
		/// <param name="replicate">If set to true, the new convar value will be set on all clients. This will only work if the convar has the FCVAR_REPLICATED flag and actually exists on clients.</param>
		/// <param name="notify">If set to true, clients will be notified that the convar has changed. This will only work if the convar has the FCVAR_NOTIFY flag.</param>

		internal static delegate*<nint, float, Bool8, Bool8, void> SetConVarFloat = &___SetConVarFloat;
		internal static delegate* unmanaged[Cdecl]<nint, float, Bool8, Bool8, void> __SetConVarFloat;
		private static void ___SetConVarFloat(nint conVar, float value, Bool8 replicate, Bool8 notify)
		{
			__SetConVarFloat(conVar, value, replicate, notify);
		}

		/// <summary>
		/// Sets the value of a double-precision floating-point console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="value">The value to set for the console variable.</param>
		/// <param name="replicate">If set to true, the new convar value will be set on all clients. This will only work if the convar has the FCVAR_REPLICATED flag and actually exists on clients.</param>
		/// <param name="notify">If set to true, clients will be notified that the convar has changed. This will only work if the convar has the FCVAR_NOTIFY flag.</param>

		internal static delegate*<nint, double, Bool8, Bool8, void> SetConVarDouble = &___SetConVarDouble;
		internal static delegate* unmanaged[Cdecl]<nint, double, Bool8, Bool8, void> __SetConVarDouble;
		private static void ___SetConVarDouble(nint conVar, double value, Bool8 replicate, Bool8 notify)
		{
			__SetConVarDouble(conVar, value, replicate, notify);
		}

		/// <summary>
		/// Sets the value of a string console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="value">The value to set for the console variable.</param>
		/// <param name="replicate">If set to true, the new convar value will be set on all clients. This will only work if the convar has the FCVAR_REPLICATED flag and actually exists on clients.</param>
		/// <param name="notify">If set to true, clients will be notified that the convar has changed. This will only work if the convar has the FCVAR_NOTIFY flag.</param>

		internal static delegate*<nint, string, Bool8, Bool8, void> SetConVarString = &___SetConVarString;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, Bool8, Bool8, void> __SetConVarString;
		private static void ___SetConVarString(nint conVar, string value, Bool8 replicate, Bool8 notify)
		{
			var __value = NativeMethods.ConstructString(value);

			try {
				__SetConVarString(conVar, &__value, replicate, notify);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__value);
			}
		}

		/// <summary>
		/// Sets the value of a color console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="value">The value to set for the console variable.</param>
		/// <param name="replicate">If set to true, the new convar value will be set on all clients. This will only work if the convar has the FCVAR_REPLICATED flag and actually exists on clients.</param>
		/// <param name="notify">If set to true, clients will be notified that the convar has changed. This will only work if the convar has the FCVAR_NOTIFY flag.</param>

		internal static delegate*<nint, int, Bool8, Bool8, void> SetConVarColor = &___SetConVarColor;
		internal static delegate* unmanaged[Cdecl]<nint, int, Bool8, Bool8, void> __SetConVarColor;
		private static void ___SetConVarColor(nint conVar, int value, Bool8 replicate, Bool8 notify)
		{
			__SetConVarColor(conVar, value, replicate, notify);
		}

		/// <summary>
		/// Sets the value of a 2D vector console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="value">The value to set for the console variable.</param>
		/// <param name="replicate">If set to true, the new convar value will be set on all clients. This will only work if the convar has the FCVAR_REPLICATED flag and actually exists on clients.</param>
		/// <param name="notify">If set to true, clients will be notified that the convar has changed. This will only work if the convar has the FCVAR_NOTIFY flag.</param>

		internal static delegate*<nint, Vector2, Bool8, Bool8, void> SetConVarVector2 = &___SetConVarVector2;
		internal static delegate* unmanaged[Cdecl]<nint, Vector2*, Bool8, Bool8, void> __SetConVarVector2;
		private static void ___SetConVarVector2(nint conVar, Vector2 value, Bool8 replicate, Bool8 notify)
		{
			__SetConVarVector2(conVar, &value, replicate, notify);
		}

		/// <summary>
		/// Sets the value of a 3D vector console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="value">The value to set for the console variable.</param>
		/// <param name="replicate">If set to true, the new convar value will be set on all clients. This will only work if the convar has the FCVAR_REPLICATED flag and actually exists on clients.</param>
		/// <param name="notify">If set to true, clients will be notified that the convar has changed. This will only work if the convar has the FCVAR_NOTIFY flag.</param>

		internal static delegate*<nint, Vector3, Bool8, Bool8, void> SetConVarVector3 = &___SetConVarVector3;
		internal static delegate* unmanaged[Cdecl]<nint, Vector3*, Bool8, Bool8, void> __SetConVarVector3;
		private static void ___SetConVarVector3(nint conVar, Vector3 value, Bool8 replicate, Bool8 notify)
		{
			__SetConVarVector3(conVar, &value, replicate, notify);
		}

		/// <summary>
		/// Sets the value of a 4D vector console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="value">The value to set for the console variable.</param>
		/// <param name="replicate">If set to true, the new convar value will be set on all clients. This will only work if the convar has the FCVAR_REPLICATED flag and actually exists on clients.</param>
		/// <param name="notify">If set to true, clients will be notified that the convar has changed. This will only work if the convar has the FCVAR_NOTIFY flag.</param>

		internal static delegate*<nint, Vector4, Bool8, Bool8, void> SetConVarVector4 = &___SetConVarVector4;
		internal static delegate* unmanaged[Cdecl]<nint, Vector4*, Bool8, Bool8, void> __SetConVarVector4;
		private static void ___SetConVarVector4(nint conVar, Vector4 value, Bool8 replicate, Bool8 notify)
		{
			__SetConVarVector4(conVar, &value, replicate, notify);
		}

		/// <summary>
		/// Sets the value of a quaternion angle console variable.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="value">The value to set for the console variable.</param>
		/// <param name="replicate">If set to true, the new convar value will be set on all clients. This will only work if the convar has the FCVAR_REPLICATED flag and actually exists on clients.</param>
		/// <param name="notify">If set to true, clients will be notified that the convar has changed. This will only work if the convar has the FCVAR_NOTIFY flag.</param>

		internal static delegate*<nint, Vector3, Bool8, Bool8, void> SetConVarQAngle = &___SetConVarQAngle;
		internal static delegate* unmanaged[Cdecl]<nint, Vector3*, Bool8, Bool8, void> __SetConVarQAngle;
		private static void ___SetConVarQAngle(nint conVar, Vector3 value, Bool8 replicate, Bool8 notify)
		{
			__SetConVarQAngle(conVar, &value, replicate, notify);
		}

		/// <summary>
		/// Replicates a console variable value to a specific client. This does not change the actual console variable value.
		/// </summary>
		/// <param name="conVar">Pointer to the console variable data.</param>
		/// <param name="clientIndex">The index of the client to replicate the value to.</param>
		/// <param name="value">The value to send to the client.</param>

		internal static delegate*<nint, int, string, void> SendConVarValue = &___SendConVarValue;
		internal static delegate* unmanaged[Cdecl]<nint, int, String192*, void> __SendConVarValue;
		private static void ___SendConVarValue(nint conVar, int clientIndex, string value)
		{
			var __value = NativeMethods.ConstructString(value);

			try {
				__SendConVarValue(conVar, clientIndex, &__value);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__value);
			}
		}

		/// <summary>
		/// Retrieves the value of a client's console variable and stores it in the output string.
		/// </summary>
		/// <param name="clientIndex">The index of the client whose console variable value is being retrieved.</param>
		/// <param name="convarName">The name of the console variable to retrieve.</param>
		/// <returns>The output string to store the client's console variable value.</returns>

		internal static delegate*<int, string, string> GetClientConVarValue = &___GetClientConVarValue;
		internal static delegate* unmanaged[Cdecl]<int, String192*, String192> __GetClientConVarValue;
		private static string ___GetClientConVarValue(int clientIndex, string convarName)
		{
			string __retVal;
			String192 __retVal_native;
			var __convarName = NativeMethods.ConstructString(convarName);

			try {
				__retVal_native = __GetClientConVarValue(clientIndex, &__convarName);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
				NativeMethods.DestroyString(&__convarName);
			}
			return __retVal;
		}

		/// <summary>
		/// Replicates a console variable value to a specific fake client. This does not change the actual console variable value.
		/// </summary>
		/// <param name="clientIndex">The index of the fake client to replicate the value to.</param>
		/// <param name="convarName">The name of the console variable.</param>
		/// <param name="convarValue">The value to set for the console variable.</param>

		internal static delegate*<int, string, string, void> SetFakeClientConVarValue = &___SetFakeClientConVarValue;
		internal static delegate* unmanaged[Cdecl]<int, String192*, String192*, void> __SetFakeClientConVarValue;
		private static void ___SetFakeClientConVarValue(int clientIndex, string convarName, string convarValue)
		{
			var __convarName = NativeMethods.ConstructString(convarName);
			var __convarValue = NativeMethods.ConstructString(convarValue);

			try {
				__SetFakeClientConVarValue(clientIndex, &__convarName, &__convarValue);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__convarName);
				NativeMethods.DestroyString(&__convarValue);
			}
		}

		/// <summary>
		/// Returns the path of the game's directory.
		/// </summary>
		/// <param name="result">A reference to a string where the game directory path will be stored.</param>

		internal static delegate*<ref string, void> GetGameDirectory = &___GetGameDirectory;
		internal static delegate* unmanaged[Cdecl]<String192*, void> __GetGameDirectory;
		private static void ___GetGameDirectory(ref string result)
		{
			var __result = NativeMethods.ConstructString(result);

			try {
				__GetGameDirectory(&__result);
				// Unmarshal - Convert native data to managed data.
				result = NativeMethods.GetStringData(&__result);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__result);
			}
		}

		/// <summary>
		/// Returns the current map name.
		/// </summary>
		/// <param name="result">A reference to a string where the current map name will be stored.</param>

		internal static delegate*<ref string, void> GetCurrentMap = &___GetCurrentMap;
		internal static delegate* unmanaged[Cdecl]<String192*, void> __GetCurrentMap;
		private static void ___GetCurrentMap(ref string result)
		{
			var __result = NativeMethods.ConstructString(result);

			try {
				__GetCurrentMap(&__result);
				// Unmarshal - Convert native data to managed data.
				result = NativeMethods.GetStringData(&__result);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__result);
			}
		}

		/// <summary>
		/// Returns whether a specified map is valid or not.
		/// </summary>
		/// <param name="mapname">The name of the map to check for validity.</param>
		/// <returns>True if the map is valid, false otherwise.</returns>

		internal static delegate*<string, Bool8> IsMapValid = &___IsMapValid;
		internal static delegate* unmanaged[Cdecl]<String192*, Bool8> __IsMapValid;
		private static Bool8 ___IsMapValid(string mapname)
		{
			Bool8 __retVal;
			var __mapname = NativeMethods.ConstructString(mapname);

			try {
				__retVal = __IsMapValid(&__mapname);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__mapname);
			}
			return __retVal;
		}

		/// <summary>
		/// Returns the game time based on the game tick.
		/// </summary>
		/// <returns>The current game time.</returns>

		internal static delegate*<float> GetGameTime = &___GetGameTime;
		internal static delegate* unmanaged[Cdecl]<float> __GetGameTime;
		private static float ___GetGameTime()
		{
			float __retVal = __GetGameTime();
			return __retVal;
		}

		/// <summary>
		/// Returns the game's internal tick count.
		/// </summary>
		/// <returns>The current tick count of the game.</returns>

		internal static delegate*<int> GetGameTickCount = &___GetGameTickCount;
		internal static delegate* unmanaged[Cdecl]<int> __GetGameTickCount;
		private static int ___GetGameTickCount()
		{
			int __retVal = __GetGameTickCount();
			return __retVal;
		}

		/// <summary>
		/// Returns the time the game took processing the last frame.
		/// </summary>
		/// <returns>The frame time of the last processed frame.</returns>

		internal static delegate*<float> GetGameFrameTime = &___GetGameFrameTime;
		internal static delegate* unmanaged[Cdecl]<float> __GetGameFrameTime;
		private static float ___GetGameFrameTime()
		{
			float __retVal = __GetGameFrameTime();
			return __retVal;
		}

		/// <summary>
		/// Returns a high-precision time value for profiling the engine.
		/// </summary>
		/// <returns>A high-precision time value.</returns>

		internal static delegate*<double> GetEngineTime = &___GetEngineTime;
		internal static delegate* unmanaged[Cdecl]<double> __GetEngineTime;
		private static double ___GetEngineTime()
		{
			double __retVal = __GetEngineTime();
			return __retVal;
		}

		/// <summary>
		/// Returns the maximum number of clients that can connect to the server.
		/// </summary>
		/// <returns>The maximum client count, or -1 if global variables are not initialized.</returns>

		internal static delegate*<int> GetMaxClients = &___GetMaxClients;
		internal static delegate* unmanaged[Cdecl]<int> __GetMaxClients;
		private static int ___GetMaxClients()
		{
			int __retVal = __GetMaxClients();
			return __retVal;
		}

		/// <summary>
		/// Precaches a given generic file.
		/// </summary>
		/// <param name="model">The name of the model to be precached.</param>
		/// <returns>An integer identifier for the generic file.</returns>

		internal static delegate*<string, int> PrecacheGeneric = &___PrecacheGeneric;
		internal static delegate* unmanaged[Cdecl]<String192*, int> __PrecacheGeneric;
		private static int ___PrecacheGeneric(string model)
		{
			int __retVal;
			var __model = NativeMethods.ConstructString(model);

			try {
				__retVal = __PrecacheGeneric(&__model);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__model);
			}
			return __retVal;
		}

		/// <summary>
		/// Checks if a specified generic file is precached.
		/// </summary>
		/// <param name="model">The name of the generic file to check.</param>
		/// <returns>No description available.</returns>

		internal static delegate*<string, Bool8> IsGenericPrecache = &___IsGenericPrecache;
		internal static delegate* unmanaged[Cdecl]<String192*, Bool8> __IsGenericPrecache;
		private static Bool8 ___IsGenericPrecache(string model)
		{
			Bool8 __retVal;
			var __model = NativeMethods.ConstructString(model);

			try {
				__retVal = __IsGenericPrecache(&__model);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__model);
			}
			return __retVal;
		}

		/// <summary>
		/// Precaches a specified model.
		/// </summary>
		/// <param name="model">The name of the model to be precached.</param>
		/// <returns>An integer identifier for the model.</returns>

		internal static delegate*<string, int> PrecacheModel = &___PrecacheModel;
		internal static delegate* unmanaged[Cdecl]<String192*, int> __PrecacheModel;
		private static int ___PrecacheModel(string model)
		{
			int __retVal;
			var __model = NativeMethods.ConstructString(model);

			try {
				__retVal = __PrecacheModel(&__model);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__model);
			}
			return __retVal;
		}

		/// <summary>
		/// Checks if a specified model is precached.
		/// </summary>
		/// <param name="model">The name of the model to check.</param>
		/// <returns>No description available.</returns>

		internal static delegate*<string, Bool8> IsModelPrecache = &___IsModelPrecache;
		internal static delegate* unmanaged[Cdecl]<String192*, Bool8> __IsModelPrecache;
		private static Bool8 ___IsModelPrecache(string model)
		{
			Bool8 __retVal;
			var __model = NativeMethods.ConstructString(model);

			try {
				__retVal = __IsModelPrecache(&__model);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__model);
			}
			return __retVal;
		}

		/// <summary>
		/// Precaches a specified sound.
		/// </summary>
		/// <param name="sound">The name of the sound to be precached.</param>
		/// <param name="preload">A boolean indicating if the sound should be preloaded.</param>
		/// <returns>True if the sound is successfully precached, false otherwise.</returns>

		internal static delegate*<string, Bool8, Bool8> PrecacheSound = &___PrecacheSound;
		internal static delegate* unmanaged[Cdecl]<String192*, Bool8, Bool8> __PrecacheSound;
		private static Bool8 ___PrecacheSound(string sound, Bool8 preload)
		{
			Bool8 __retVal;
			var __sound = NativeMethods.ConstructString(sound);

			try {
				__retVal = __PrecacheSound(&__sound, preload);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__sound);
			}
			return __retVal;
		}

		/// <summary>
		/// Checks if a specified sound is precached.
		/// </summary>
		/// <param name="sound">The name of the sound to check.</param>
		/// <returns>True if the sound is precached, false otherwise.</returns>

		internal static delegate*<string, Bool8> IsSoundPrecached = &___IsSoundPrecached;
		internal static delegate* unmanaged[Cdecl]<String192*, Bool8> __IsSoundPrecached;
		private static Bool8 ___IsSoundPrecached(string sound)
		{
			Bool8 __retVal;
			var __sound = NativeMethods.ConstructString(sound);

			try {
				__retVal = __IsSoundPrecached(&__sound);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__sound);
			}
			return __retVal;
		}

		/// <summary>
		/// Precaches a specified decal.
		/// </summary>
		/// <param name="decal">The name of the decal to be precached.</param>
		/// <param name="preload">A boolean indicating if the decal should be preloaded.</param>
		/// <returns>An integer identifier for the decal.</returns>

		internal static delegate*<string, Bool8, int> PrecacheDecal = &___PrecacheDecal;
		internal static delegate* unmanaged[Cdecl]<String192*, Bool8, int> __PrecacheDecal;
		private static int ___PrecacheDecal(string decal, Bool8 preload)
		{
			int __retVal;
			var __decal = NativeMethods.ConstructString(decal);

			try {
				__retVal = __PrecacheDecal(&__decal, preload);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__decal);
			}
			return __retVal;
		}

		/// <summary>
		/// Checks if a specified decal is precached.
		/// </summary>
		/// <param name="decal">The name of the decal to check.</param>
		/// <returns>True if the decal is precached, false otherwise.</returns>

		internal static delegate*<string, Bool8> IsDecalPrecached = &___IsDecalPrecached;
		internal static delegate* unmanaged[Cdecl]<String192*, Bool8> __IsDecalPrecached;
		private static Bool8 ___IsDecalPrecached(string decal)
		{
			Bool8 __retVal;
			var __decal = NativeMethods.ConstructString(decal);

			try {
				__retVal = __IsDecalPrecached(&__decal);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__decal);
			}
			return __retVal;
		}

		/// <summary>
		/// Returns a pointer to the Economy Item System.
		/// </summary>
		/// <returns>A pointer to the Econ Item System.</returns>

		internal static delegate*<nint> GetEconItemSystem = &___GetEconItemSystem;
		internal static delegate* unmanaged[Cdecl]<nint> __GetEconItemSystem;
		private static nint ___GetEconItemSystem()
		{
			nint __retVal = __GetEconItemSystem();
			return __retVal;
		}

		/// <summary>
		/// Checks if the server is currently paused.
		/// </summary>
		/// <returns>True if the server is paused, false otherwise.</returns>

		internal static delegate*<Bool8> IsServerPaused = &___IsServerPaused;
		internal static delegate* unmanaged[Cdecl]<Bool8> __IsServerPaused;
		private static Bool8 ___IsServerPaused()
		{
			Bool8 __retVal = __IsServerPaused();
			return __retVal;
		}

		/// <summary>
		/// Queues a task to be executed on the next frame.
		/// </summary>
		/// <param name="callback">A callback function to be executed on the next frame.</param>
		/// <param name="userData">An array intended to hold user-related data, allowing for elements of any type.</param>
		/// <remarks>
		/// Callback TaskCallback: Defines a QueueTask Callback.
		/// - Parameter userData: An array intended to hold user-related data, allowing for elements of any type.
		/// - Returns: No description available. (void)
		/// </remarks>

		internal static delegate*<TaskCallback, object?[], void> QueueTaskForNextFrame = &___QueueTaskForNextFrame;
		internal static delegate* unmanaged[Cdecl]<nint, Vector192*, void> __QueueTaskForNextFrame;
		private static void ___QueueTaskForNextFrame(TaskCallback callback, object?[] userData)
		{
			var __callback = Marshalling.GetFunctionPointerForDelegate(callback);
			var __userData = NativeMethods.ConstructVectorVariant(userData, userData.Length);

			try {
				__QueueTaskForNextFrame(__callback, &__userData);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyVectorVariant(&__userData);
			}
		}

		/// <summary>
		/// Queues a task to be executed on the next world update.
		/// </summary>
		/// <param name="callback">A callback function to be executed on the next world update.</param>
		/// <param name="userData">An array intended to hold user-related data, allowing for elements of any type.</param>
		/// <remarks>
		/// Callback TaskCallback: Defines a QueueTask Callback.
		/// - Parameter userData: An array intended to hold user-related data, allowing for elements of any type.
		/// - Returns: No description available. (void)
		/// </remarks>

		internal static delegate*<TaskCallback, object?[], void> QueueTaskForNextWorldUpdate = &___QueueTaskForNextWorldUpdate;
		internal static delegate* unmanaged[Cdecl]<nint, Vector192*, void> __QueueTaskForNextWorldUpdate;
		private static void ___QueueTaskForNextWorldUpdate(TaskCallback callback, object?[] userData)
		{
			var __callback = Marshalling.GetFunctionPointerForDelegate(callback);
			var __userData = NativeMethods.ConstructVectorVariant(userData, userData.Length);

			try {
				__QueueTaskForNextWorldUpdate(__callback, &__userData);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyVectorVariant(&__userData);
			}
		}

		/// <summary>
		/// Returns the duration of a specified sound.
		/// </summary>
		/// <param name="name">The name of the sound to check.</param>
		/// <returns>The duration of the sound in seconds.</returns>

		internal static delegate*<string, float> GetSoundDuration = &___GetSoundDuration;
		internal static delegate* unmanaged[Cdecl]<String192*, float> __GetSoundDuration;
		private static float ___GetSoundDuration(string name)
		{
			float __retVal;
			var __name = NativeMethods.ConstructString(name);

			try {
				__retVal = __GetSoundDuration(&__name);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
			}
			return __retVal;
		}

		/// <summary>
		/// Emits a sound from a specified entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity that will emit the sound.</param>
		/// <param name="sound">The name of the sound to emit.</param>
		/// <param name="pitch">The pitch of the sound.</param>
		/// <param name="volume">The volume of the sound.</param>
		/// <param name="delay">The delay before the sound is played.</param>

		internal static delegate*<int, string, int, float, float, void> EmitSound = &___EmitSound;
		internal static delegate* unmanaged[Cdecl]<int, String192*, int, float, float, void> __EmitSound;
		private static void ___EmitSound(int entityHandle, string sound, int pitch, float volume, float delay)
		{
			var __sound = NativeMethods.ConstructString(sound);

			try {
				__EmitSound(entityHandle, &__sound, pitch, volume, delay);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__sound);
			}
		}

		/// <summary>
		/// Emits a sound to a specific client.
		/// </summary>
		/// <param name="clientIndex">The index of the client to whom the sound will be emitted.</param>
		/// <param name="channel">The channel through which the sound will be played.</param>
		/// <param name="sound">The name of the sound to emit.</param>
		/// <param name="volume">The volume of the sound.</param>
		/// <param name="soundLevel">The level of the sound.</param>
		/// <param name="flags">Additional flags for sound playback.</param>
		/// <param name="pitch">The pitch of the sound.</param>
		/// <param name="origin">The origin of the sound in 3D space.</param>
		/// <param name="soundTime">The time at which the sound should be played.</param>

		internal static delegate*<int, int, string, float, int, int, int, Vector3, float, void> EmitSoundToClient = &___EmitSoundToClient;
		internal static delegate* unmanaged[Cdecl]<int, int, String192*, float, int, int, int, Vector3*, float, void> __EmitSoundToClient;
		private static void ___EmitSoundToClient(int clientIndex, int channel, string sound, float volume, int soundLevel, int flags, int pitch, Vector3 origin, float soundTime)
		{
			var __sound = NativeMethods.ConstructString(sound);

			try {
				__EmitSoundToClient(clientIndex, channel, &__sound, volume, soundLevel, flags, pitch, &origin, soundTime);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__sound);
			}
		}

		/// <summary>
		/// Converts an entity index into an entity pointer.
		/// </summary>
		/// <param name="entityIndex">The index of the entity to convert.</param>
		/// <returns>A pointer to the entity instance, or nullptr if the entity does not exist.</returns>

		internal static delegate*<int, nint> EntIndexToEntPointer = &___EntIndexToEntPointer;
		internal static delegate* unmanaged[Cdecl]<int, nint> __EntIndexToEntPointer;
		private static nint ___EntIndexToEntPointer(int entityIndex)
		{
			nint __retVal = __EntIndexToEntPointer(entityIndex);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the entity index from an entity pointer.
		/// </summary>
		/// <param name="entity">A pointer to the entity whose index is to be retrieved.</param>
		/// <returns>The index of the entity, or -1 if the entity is nullptr.</returns>

		internal static delegate*<nint, int> EntPointerToEntIndex = &___EntPointerToEntIndex;
		internal static delegate* unmanaged[Cdecl]<nint, int> __EntPointerToEntIndex;
		private static int ___EntPointerToEntIndex(nint entity)
		{
			int __retVal = __EntPointerToEntIndex(entity);
			return __retVal;
		}

		/// <summary>
		/// Converts an entity pointer into an entity handle.
		/// </summary>
		/// <param name="entity">A pointer to the entity to convert.</param>
		/// <returns>The entity handle as an integer, or INVALID_EHANDLE_INDEX if the entity is nullptr.</returns>

		internal static delegate*<nint, int> EntPointerToEntHandle = &___EntPointerToEntHandle;
		internal static delegate* unmanaged[Cdecl]<nint, int> __EntPointerToEntHandle;
		private static int ___EntPointerToEntHandle(nint entity)
		{
			int __retVal = __EntPointerToEntHandle(entity);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the entity pointer from an entity handle.
		/// </summary>
		/// <param name="entityHandle">The entity handle to convert.</param>
		/// <returns>A pointer to the entity instance, or nullptr if the handle is invalid.</returns>

		internal static delegate*<int, nint> EntHandleToEntPointer = &___EntHandleToEntPointer;
		internal static delegate* unmanaged[Cdecl]<int, nint> __EntHandleToEntPointer;
		private static nint ___EntHandleToEntPointer(int entityHandle)
		{
			nint __retVal = __EntHandleToEntPointer(entityHandle);
			return __retVal;
		}

		/// <summary>
		/// Converts an entity index into an entity handle.
		/// </summary>
		/// <param name="entityIndex">The index of the entity to convert.</param>
		/// <returns>The entity handle as an integer, or INVALID_EHANDLE_INDEX if the entity index is invalid.</returns>

		internal static delegate*<int, int> EntIndexToEntHandle = &___EntIndexToEntHandle;
		internal static delegate* unmanaged[Cdecl]<int, int> __EntIndexToEntHandle;
		private static int ___EntIndexToEntHandle(int entityIndex)
		{
			int __retVal = __EntIndexToEntHandle(entityIndex);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the entity index from an entity handle.
		/// </summary>
		/// <param name="entityHandle">The entity handle from which to retrieve the index.</param>
		/// <returns>The index of the entity, or -1 if the handle is invalid.</returns>

		internal static delegate*<int, int> EntHandleToEntIndex = &___EntHandleToEntIndex;
		internal static delegate* unmanaged[Cdecl]<int, int> __EntHandleToEntIndex;
		private static int ___EntHandleToEntIndex(int entityHandle)
		{
			int __retVal = __EntHandleToEntIndex(entityHandle);
			return __retVal;
		}

		/// <summary>
		/// Checks if the provided entity handle is valid.
		/// </summary>
		/// <param name="entityHandle">The entity handle to check.</param>
		/// <returns>True if the entity handle is valid, false otherwise.</returns>

		internal static delegate*<int, Bool8> IsValidEntHandle = &___IsValidEntHandle;
		internal static delegate* unmanaged[Cdecl]<int, Bool8> __IsValidEntHandle;
		private static Bool8 ___IsValidEntHandle(int entityHandle)
		{
			Bool8 __retVal = __IsValidEntHandle(entityHandle);
			return __retVal;
		}

		/// <summary>
		/// Checks if the provided entity pointer is valid.
		/// </summary>
		/// <param name="entity">The entity pointer to check.</param>
		/// <returns>True if the entity pointer is valid, false otherwise.</returns>

		internal static delegate*<nint, Bool8> IsValidEntPointer = &___IsValidEntPointer;
		internal static delegate* unmanaged[Cdecl]<nint, Bool8> __IsValidEntPointer;
		private static Bool8 ___IsValidEntPointer(nint entity)
		{
			Bool8 __retVal = __IsValidEntPointer(entity);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the pointer to the first active entity.
		/// </summary>
		/// <returns>A pointer to the first active entity.</returns>

		internal static delegate*<nint> GetFirstActiveEntity = &___GetFirstActiveEntity;
		internal static delegate* unmanaged[Cdecl]<nint> __GetFirstActiveEntity;
		private static nint ___GetFirstActiveEntity()
		{
			nint __retVal = __GetFirstActiveEntity();
			return __retVal;
		}

		/// <summary>
		/// Retrieves a pointer to the concrete entity list.
		/// </summary>
		/// <returns>A pointer to the entity list structure.</returns>

		internal static delegate*<nint> GetConcreteEntityListPointer = &___GetConcreteEntityListPointer;
		internal static delegate* unmanaged[Cdecl]<nint> __GetConcreteEntityListPointer;
		private static nint ___GetConcreteEntityListPointer()
		{
			nint __retVal = __GetConcreteEntityListPointer();
			return __retVal;
		}

		/// <summary>
		/// Adds an entity output hook on a specified entity class name.
		/// </summary>
		/// <param name="szClassname">The class name of the entity to hook the output for.</param>
		/// <param name="szOutput">The output event name to hook.</param>
		/// <param name="callback">The callback function to invoke when the output is fired.</param>
		/// <param name="post">Indicates whether the hook should be a post-hook (true) or pre-hook (false).</param>
		/// <remarks>
		/// Callback HookEntityOutputCallback: This function is a callback handler for entity output events. It is triggered when a specific output event is activated, and it handles the process by passing the activator, the caller, and a delay parameter for the output.
		/// - Parameter activatorHandle: The activator is an identifier for the entity or object that triggers the event. It is typically a reference to the entity that caused the output to occur.
		/// - Parameter callerHandle: The caller represents the entity or object that calls the output function. It can be used to identify which entity initiated the action that caused the event.
		/// - Parameter flDelay: This parameter specifies the delay in seconds before the output action is executed. It allows the output to be triggered after a certain period of time, providing flexibility in handling time-based behaviors.
		/// - Returns: Indicates the result of the action execution. (int32)
		/// </remarks>

		internal static delegate*<string, string, HookEntityOutputCallback, Bool8, void> HookEntityOutput = &___HookEntityOutput;
		internal static delegate* unmanaged[Cdecl]<String192*, String192*, nint, Bool8, void> __HookEntityOutput;
		private static void ___HookEntityOutput(string szClassname, string szOutput, HookEntityOutputCallback callback, Bool8 post)
		{
			var __szClassname = NativeMethods.ConstructString(szClassname);
			var __szOutput = NativeMethods.ConstructString(szOutput);

			try {
				__HookEntityOutput(&__szClassname, &__szOutput, Marshal.GetFunctionPointerForDelegate(callback), post);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__szClassname);
				NativeMethods.DestroyString(&__szOutput);
			}
		}

		/// <summary>
		/// Removes an entity output hook.
		/// </summary>
		/// <param name="szClassname">The class name of the entity from which to unhook the output.</param>
		/// <param name="szOutput">The output event name to unhook.</param>
		/// <param name="callback">The callback function that was previously hooked.</param>
		/// <param name="post">Indicates whether the hook was a post-hook (true) or pre-hook (false).</param>
		/// <remarks>
		/// Callback HookEntityOutputCallback: This function is a callback handler for entity output events. It is triggered when a specific output event is activated, and it handles the process by passing the activator, the caller, and a delay parameter for the output.
		/// - Parameter activatorHandle: The activator is an identifier for the entity or object that triggers the event. It is typically a reference to the entity that caused the output to occur.
		/// - Parameter callerHandle: The caller represents the entity or object that calls the output function. It can be used to identify which entity initiated the action that caused the event.
		/// - Parameter flDelay: This parameter specifies the delay in seconds before the output action is executed. It allows the output to be triggered after a certain period of time, providing flexibility in handling time-based behaviors.
		/// - Returns: Indicates the result of the action execution. (int32)
		/// </remarks>

		internal static delegate*<string, string, HookEntityOutputCallback, Bool8, void> UnhookEntityOutput = &___UnhookEntityOutput;
		internal static delegate* unmanaged[Cdecl]<String192*, String192*, nint, Bool8, void> __UnhookEntityOutput;
		private static void ___UnhookEntityOutput(string szClassname, string szOutput, HookEntityOutputCallback callback, Bool8 post)
		{
			var __szClassname = NativeMethods.ConstructString(szClassname);
			var __szOutput = NativeMethods.ConstructString(szOutput);

			try {
				__UnhookEntityOutput(&__szClassname, &__szOutput, Marshal.GetFunctionPointerForDelegate(callback), post);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__szClassname);
				NativeMethods.DestroyString(&__szOutput);
			}
		}

		/// <summary>
		/// Searches for an entity by classname.
		/// </summary>
		/// <param name="startEntity">The entity handle from which to start the search.</param>
		/// <param name="classname">The class name of the entity to search for.</param>
		/// <returns>The entity handle of the found entity, or INVALID_EHANDLE_INDEX if no entity is found.</returns>

		internal static delegate*<int, string, int> FindEntityByClassname = &___FindEntityByClassname;
		internal static delegate* unmanaged[Cdecl]<int, String192*, int> __FindEntityByClassname;
		private static int ___FindEntityByClassname(int startEntity, string classname)
		{
			int __retVal;
			var __classname = NativeMethods.ConstructString(classname);

			try {
				__retVal = __FindEntityByClassname(startEntity, &__classname);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__classname);
			}
			return __retVal;
		}

		/// <summary>
		/// Searches for an entity by name.
		/// </summary>
		/// <param name="startEntity">The entity handle from which to start the search.</param>
		/// <param name="name">The name of the entity to search for.</param>
		/// <returns>The entity handle of the found entity, or INVALID_EHANDLE_INDEX if no entity is found.</returns>

		internal static delegate*<int, string, int> FindEntityByName = &___FindEntityByName;
		internal static delegate* unmanaged[Cdecl]<int, String192*, int> __FindEntityByName;
		private static int ___FindEntityByName(int startEntity, string name)
		{
			int __retVal;
			var __name = NativeMethods.ConstructString(name);

			try {
				__retVal = __FindEntityByName(startEntity, &__name);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
			}
			return __retVal;
		}

		/// <summary>
		/// Creates an entity by string name but does not spawn it.
		/// </summary>
		/// <param name="className">The class name of the entity to create.</param>
		/// <returns>The entity handle of the created entity, or INVALID_EHANDLE_INDEX if the entity could not be created.</returns>

		internal static delegate*<string, int> CreateEntityByName = &___CreateEntityByName;
		internal static delegate* unmanaged[Cdecl]<String192*, int> __CreateEntityByName;
		private static int ___CreateEntityByName(string className)
		{
			int __retVal;
			var __className = NativeMethods.ConstructString(className);

			try {
				__retVal = __CreateEntityByName(&__className);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
			}
			return __retVal;
		}

		/// <summary>
		/// Spawns an entity into the game.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity to spawn.</param>

		internal static delegate*<int, void> DispatchSpawn = &___DispatchSpawn;
		internal static delegate* unmanaged[Cdecl]<int, void> __DispatchSpawn;
		private static void ___DispatchSpawn(int entityHandle)
		{
			__DispatchSpawn(entityHandle);
		}

		/// <summary>
		/// Spawns an entity into the game with key-value properties.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity to spawn.</param>
		/// <param name="keys">A vector of keys representing the property names to set on the entity.</param>
		/// <param name="values">A vector of values corresponding to the keys, representing the property values to set on the entity.</param>

		internal static delegate*<int, string[], object?[], void> DispatchSpawn2 = &___DispatchSpawn2;
		internal static delegate* unmanaged[Cdecl]<int, Vector192*, Vector192*, void> __DispatchSpawn2;
		private static void ___DispatchSpawn2(int entityHandle, string[] keys, object?[] values)
		{
			var __keys = NativeMethods.ConstructVectorString(keys, keys.Length);
			var __values = NativeMethods.ConstructVectorVariant(values, values.Length);

			try {
				__DispatchSpawn2(entityHandle, &__keys, &__values);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyVectorString(&__keys);
				NativeMethods.DestroyVectorVariant(&__values);
			}
		}

		/// <summary>
		/// Marks an entity for deletion.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity to be deleted.</param>

		internal static delegate*<int, void> RemoveEntity = &___RemoveEntity;
		internal static delegate* unmanaged[Cdecl]<int, void> __RemoveEntity;
		private static void ___RemoveEntity(int entityHandle)
		{
			__RemoveEntity(entityHandle);
		}

		/// <summary>
		/// Retrieves the class name of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose class name is to be retrieved.</param>
		/// <returns>A string where the class name will be stored.</returns>

		internal static delegate*<int, string> GetEntityClassname = &___GetEntityClassname;
		internal static delegate* unmanaged[Cdecl]<int, String192> __GetEntityClassname;
		private static string ___GetEntityClassname(int entityHandle)
		{
			string __retVal;
			String192 __retVal_native;

			try {
				__retVal_native = __GetEntityClassname(entityHandle);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the name of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose name is to be retrieved.</param>
		/// <returns>No description available.</returns>

		internal static delegate*<int, string> GetEntityName = &___GetEntityName;
		internal static delegate* unmanaged[Cdecl]<int, String192> __GetEntityName;
		private static string ___GetEntityName(int entityHandle)
		{
			string __retVal;
			String192 __retVal_native;

			try {
				__retVal_native = __GetEntityName(entityHandle);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
			}
			return __retVal;
		}

		/// <summary>
		/// Sets the name of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose name is to be set.</param>
		/// <param name="name">The new name to set for the entity.</param>

		internal static delegate*<int, string, void> SetEntityName = &___SetEntityName;
		internal static delegate* unmanaged[Cdecl]<int, String192*, void> __SetEntityName;
		private static void ___SetEntityName(int entityHandle, string name)
		{
			var __name = NativeMethods.ConstructString(name);

			try {
				__SetEntityName(entityHandle, &__name);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
			}
		}

		/// <summary>
		/// Retrieves the movement type of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose movement type is to be retrieved.</param>
		/// <returns>The movement type of the entity, or 0 if the entity is invalid.</returns>

		internal static delegate*<int, int> GetEntityMoveType = &___GetEntityMoveType;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetEntityMoveType;
		private static int ___GetEntityMoveType(int entityHandle)
		{
			int __retVal = __GetEntityMoveType(entityHandle);
			return __retVal;
		}

		/// <summary>
		/// Sets the movement type of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose movement type is to be set.</param>
		/// <param name="moveType">The new movement type to set for the entity.</param>

		internal static delegate*<int, int, void> SetEntityMoveType = &___SetEntityMoveType;
		internal static delegate* unmanaged[Cdecl]<int, int, void> __SetEntityMoveType;
		private static void ___SetEntityMoveType(int entityHandle, int moveType)
		{
			__SetEntityMoveType(entityHandle, moveType);
		}

		/// <summary>
		/// Retrieves the gravity scale of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose gravity scale is to be retrieved.</param>
		/// <returns>The gravity scale of the entity, or 0.0f if the entity is invalid.</returns>

		internal static delegate*<int, float> GetEntityGravity = &___GetEntityGravity;
		internal static delegate* unmanaged[Cdecl]<int, float> __GetEntityGravity;
		private static float ___GetEntityGravity(int entityHandle)
		{
			float __retVal = __GetEntityGravity(entityHandle);
			return __retVal;
		}

		/// <summary>
		/// Sets the gravity scale of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose gravity scale is to be set.</param>
		/// <param name="gravity">The new gravity scale to set for the entity.</param>

		internal static delegate*<int, float, void> SetEntityGravity = &___SetEntityGravity;
		internal static delegate* unmanaged[Cdecl]<int, float, void> __SetEntityGravity;
		private static void ___SetEntityGravity(int entityHandle, float gravity)
		{
			__SetEntityGravity(entityHandle, gravity);
		}

		/// <summary>
		/// Retrieves the flags of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose flags are to be retrieved.</param>
		/// <returns>The flags of the entity, or 0 if the entity is invalid.</returns>

		internal static delegate*<int, int> GetEntityFlags = &___GetEntityFlags;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetEntityFlags;
		private static int ___GetEntityFlags(int entityHandle)
		{
			int __retVal = __GetEntityFlags(entityHandle);
			return __retVal;
		}

		/// <summary>
		/// Sets the flags of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose flags are to be set.</param>
		/// <param name="flags">The new flags to set for the entity.</param>

		internal static delegate*<int, int, void> SetEntityFlags = &___SetEntityFlags;
		internal static delegate* unmanaged[Cdecl]<int, int, void> __SetEntityFlags;
		private static void ___SetEntityFlags(int entityHandle, int flags)
		{
			__SetEntityFlags(entityHandle, flags);
		}

		/// <summary>
		/// Retrieves the render color of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose render color is to be retrieved.</param>
		/// <returns>The raw color value of the entity's render color, or 0 if the entity is invalid.</returns>

		internal static delegate*<int, int> GetEntityRenderColor = &___GetEntityRenderColor;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetEntityRenderColor;
		private static int ___GetEntityRenderColor(int entityHandle)
		{
			int __retVal = __GetEntityRenderColor(entityHandle);
			return __retVal;
		}

		/// <summary>
		/// Sets the render color of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose render color is to be set.</param>
		/// <param name="color">The new raw color value to set for the entity's render color.</param>

		internal static delegate*<int, int, void> SetEntityRenderColor = &___SetEntityRenderColor;
		internal static delegate* unmanaged[Cdecl]<int, int, void> __SetEntityRenderColor;
		private static void ___SetEntityRenderColor(int entityHandle, int color)
		{
			__SetEntityRenderColor(entityHandle, color);
		}

		/// <summary>
		/// Retrieves the render mode of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose render mode is to be retrieved.</param>
		/// <returns>The render mode of the entity, or 0 if the entity is invalid.</returns>

		internal static delegate*<int, sbyte> GetEntityRenderMode = &___GetEntityRenderMode;
		internal static delegate* unmanaged[Cdecl]<int, sbyte> __GetEntityRenderMode;
		private static sbyte ___GetEntityRenderMode(int entityHandle)
		{
			sbyte __retVal = __GetEntityRenderMode(entityHandle);
			return __retVal;
		}

		/// <summary>
		/// Sets the render mode of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose render mode is to be set.</param>
		/// <param name="renderMode">The new render mode to set for the entity.</param>

		internal static delegate*<int, sbyte, void> SetEntityRenderMode = &___SetEntityRenderMode;
		internal static delegate* unmanaged[Cdecl]<int, sbyte, void> __SetEntityRenderMode;
		private static void ___SetEntityRenderMode(int entityHandle, sbyte renderMode)
		{
			__SetEntityRenderMode(entityHandle, renderMode);
		}

		/// <summary>
		/// Retrieves the health of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose health is to be retrieved.</param>
		/// <returns>The health of the entity, or 0 if the entity is invalid.</returns>

		internal static delegate*<int, int> GetEntityHealth = &___GetEntityHealth;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetEntityHealth;
		private static int ___GetEntityHealth(int entityHandle)
		{
			int __retVal = __GetEntityHealth(entityHandle);
			return __retVal;
		}

		/// <summary>
		/// Sets the health of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose health is to be set.</param>
		/// <param name="health">The new health value to set for the entity.</param>

		internal static delegate*<int, int, void> SetEntityHealth = &___SetEntityHealth;
		internal static delegate* unmanaged[Cdecl]<int, int, void> __SetEntityHealth;
		private static void ___SetEntityHealth(int entityHandle, int health)
		{
			__SetEntityHealth(entityHandle, health);
		}

		/// <summary>
		/// Retrieves the team number of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose team number is to be retrieved.</param>
		/// <returns>The team number of the entity, or 0 if the entity is invalid.</returns>

		internal static delegate*<int, int> GetTeamEntity = &___GetTeamEntity;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetTeamEntity;
		private static int ___GetTeamEntity(int entityHandle)
		{
			int __retVal = __GetTeamEntity(entityHandle);
			return __retVal;
		}

		/// <summary>
		/// Sets the team number of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose team number is to be set.</param>
		/// <param name="team">The new team number to set for the entity.</param>

		internal static delegate*<int, int, void> SetTeamEntity = &___SetTeamEntity;
		internal static delegate* unmanaged[Cdecl]<int, int, void> __SetTeamEntity;
		private static void ___SetTeamEntity(int entityHandle, int team)
		{
			__SetTeamEntity(entityHandle, team);
		}

		/// <summary>
		/// Retrieves the owner of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose owner is to be retrieved.</param>
		/// <returns>The handle of the owner entity, or INVALID_EHANDLE_INDEX if the entity is invalid.</returns>

		internal static delegate*<int, int> GetEntityOwner = &___GetEntityOwner;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetEntityOwner;
		private static int ___GetEntityOwner(int entityHandle)
		{
			int __retVal = __GetEntityOwner(entityHandle);
			return __retVal;
		}

		/// <summary>
		/// Sets the owner of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose owner is to be set.</param>
		/// <param name="ownerHandle">The handle of the new owner entity.</param>

		internal static delegate*<int, int, void> SetEntityOwner = &___SetEntityOwner;
		internal static delegate* unmanaged[Cdecl]<int, int, void> __SetEntityOwner;
		private static void ___SetEntityOwner(int entityHandle, int ownerHandle)
		{
			__SetEntityOwner(entityHandle, ownerHandle);
		}

		/// <summary>
		/// Retrieves the parent of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose parent is to be retrieved.</param>
		/// <returns>The handle of the parent entity, or INVALID_EHANDLE_INDEX if the entity is invalid.</returns>

		internal static delegate*<int, int> GetEntityParent = &___GetEntityParent;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetEntityParent;
		private static int ___GetEntityParent(int entityHandle)
		{
			int __retVal = __GetEntityParent(entityHandle);
			return __retVal;
		}

		/// <summary>
		/// Sets the parent of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose parent is to be set.</param>
		/// <param name="parentHandle">The handle of the new parent entity.</param>

		internal static delegate*<int, int, void> SetEntityParent = &___SetEntityParent;
		internal static delegate* unmanaged[Cdecl]<int, int, void> __SetEntityParent;
		private static void ___SetEntityParent(int entityHandle, int parentHandle)
		{
			__SetEntityParent(entityHandle, parentHandle);
		}

		/// <summary>
		/// Retrieves the absolute origin of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose absolute origin is to be retrieved.</param>
		/// <returns>A vector where the absolute origin will be stored.</returns>

		internal static delegate*<int, Vector3> GetEntityAbsOrigin = &___GetEntityAbsOrigin;
		internal static delegate* unmanaged[Cdecl]<int, Vector3> __GetEntityAbsOrigin;
		private static Vector3 ___GetEntityAbsOrigin(int entityHandle)
		{
			Vector3 __retVal = __GetEntityAbsOrigin(entityHandle);
			return __retVal;
		}

		/// <summary>
		/// Sets the absolute origin of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose absolute origin is to be set.</param>
		/// <param name="origin">The new absolute origin to set for the entity.</param>

		internal static delegate*<int, Vector3, void> SetEntityAbsOrigin = &___SetEntityAbsOrigin;
		internal static delegate* unmanaged[Cdecl]<int, Vector3*, void> __SetEntityAbsOrigin;
		private static void ___SetEntityAbsOrigin(int entityHandle, Vector3 origin)
		{
			__SetEntityAbsOrigin(entityHandle, &origin);
		}

		/// <summary>
		/// Retrieves the angular rotation of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose angular rotation is to be retrieved.</param>
		/// <returns>A QAngle where the angular rotation will be stored.</returns>

		internal static delegate*<int, Vector3> GetEntityAngRotation = &___GetEntityAngRotation;
		internal static delegate* unmanaged[Cdecl]<int, Vector3> __GetEntityAngRotation;
		private static Vector3 ___GetEntityAngRotation(int entityHandle)
		{
			Vector3 __retVal = __GetEntityAngRotation(entityHandle);
			return __retVal;
		}

		/// <summary>
		/// Sets the angular rotation of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose angular rotation is to be set.</param>
		/// <param name="angle">The new angular rotation to set for the entity.</param>

		internal static delegate*<int, Vector3, void> SetEntityAngRotation = &___SetEntityAngRotation;
		internal static delegate* unmanaged[Cdecl]<int, Vector3*, void> __SetEntityAngRotation;
		private static void ___SetEntityAngRotation(int entityHandle, Vector3 angle)
		{
			__SetEntityAngRotation(entityHandle, &angle);
		}

		/// <summary>
		/// Retrieves the absolute velocity of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose absolute velocity is to be retrieved.</param>
		/// <returns>A vector where the absolute velocity will be stored.</returns>

		internal static delegate*<int, Vector3> GetEntityAbsVelocity = &___GetEntityAbsVelocity;
		internal static delegate* unmanaged[Cdecl]<int, Vector3> __GetEntityAbsVelocity;
		private static Vector3 ___GetEntityAbsVelocity(int entityHandle)
		{
			Vector3 __retVal = __GetEntityAbsVelocity(entityHandle);
			return __retVal;
		}

		/// <summary>
		/// Sets the absolute velocity of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose absolute velocity is to be set.</param>
		/// <param name="velocity">The new absolute velocity to set for the entity.</param>

		internal static delegate*<int, Vector3, void> SetEntityAbsVelocity = &___SetEntityAbsVelocity;
		internal static delegate* unmanaged[Cdecl]<int, Vector3*, void> __SetEntityAbsVelocity;
		private static void ___SetEntityAbsVelocity(int entityHandle, Vector3 velocity)
		{
			__SetEntityAbsVelocity(entityHandle, &velocity);
		}

		/// <summary>
		/// Retrieves the model name of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose model name is to be retrieved.</param>
		/// <returns>A string where the model name will be stored.</returns>

		internal static delegate*<int, string> GetEntityModel = &___GetEntityModel;
		internal static delegate* unmanaged[Cdecl]<int, String192> __GetEntityModel;
		private static string ___GetEntityModel(int entityHandle)
		{
			string __retVal;
			String192 __retVal_native;

			try {
				__retVal_native = __GetEntityModel(entityHandle);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
			}
			return __retVal;
		}

		/// <summary>
		/// Sets the model name of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose model name is to be set.</param>
		/// <param name="model">The new model name to set for the entity.</param>

		internal static delegate*<int, string, void> SetEntityModel = &___SetEntityModel;
		internal static delegate* unmanaged[Cdecl]<int, String192*, void> __SetEntityModel;
		private static void ___SetEntityModel(int entityHandle, string model)
		{
			var __model = NativeMethods.ConstructString(model);

			try {
				__SetEntityModel(entityHandle, &__model);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__model);
			}
		}

		/// <summary>
		/// Retrieves the water level of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose water level is to be retrieved.</param>
		/// <returns>The water level of the entity, or 0.0f if the entity is invalid.</returns>

		internal static delegate*<int, float> GetEntityWaterLevel = &___GetEntityWaterLevel;
		internal static delegate* unmanaged[Cdecl]<int, float> __GetEntityWaterLevel;
		private static float ___GetEntityWaterLevel(int entityHandle)
		{
			float __retVal = __GetEntityWaterLevel(entityHandle);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the ground entity of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose ground entity is to be retrieved.</param>
		/// <returns>The handle of the ground entity, or INVALID_EHANDLE_INDEX if the entity is invalid.</returns>

		internal static delegate*<int, int> GetEntityGroundEntity = &___GetEntityGroundEntity;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetEntityGroundEntity;
		private static int ___GetEntityGroundEntity(int entityHandle)
		{
			int __retVal = __GetEntityGroundEntity(entityHandle);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the effects of an entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity whose effects are to be retrieved.</param>
		/// <returns>The effect flags of the entity, or 0 if the entity is invalid.</returns>

		internal static delegate*<int, int> GetEntityEffects = &___GetEntityEffects;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetEntityEffects;
		private static int ___GetEntityEffects(int entityHandle)
		{
			int __retVal = __GetEntityEffects(entityHandle);
			return __retVal;
		}

		/// <summary>
		/// Teleports an entity to a specified location and orientation.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity to teleport.</param>
		/// <param name="origin">A pointer to a Vector representing the new absolute position. Can be nullptr.</param>
		/// <param name="angles">A pointer to a QAngle representing the new orientation. Can be nullptr.</param>
		/// <param name="velocity">A pointer to a Vector representing the new velocity. Can be nullptr.</param>

		internal static delegate*<int, nint, nint, nint, void> TeleportEntity = &___TeleportEntity;
		internal static delegate* unmanaged[Cdecl]<int, nint, nint, nint, void> __TeleportEntity;
		private static void ___TeleportEntity(int entityHandle, nint origin, nint angles, nint velocity)
		{
			__TeleportEntity(entityHandle, origin, angles, velocity);
		}

		/// <summary>
		/// Invokes a named input method on a specified entity.
		/// </summary>
		/// <param name="entityHandle">The handle of the target entity that will receive the input.</param>
		/// <param name="inputName">The name of the input action to invoke.</param>
		/// <param name="activatorHandle">The handle of the entity that initiated the sequence of actions.</param>
		/// <param name="callerHandle">The handle of the entity sending this event.</param>
		/// <param name="value">The value associated with the input action.</param>
		/// <param name="type">The type or classification of the value.</param>
		/// <param name="outputId">An identifier for tracking the output of this operation.</param>

		internal static delegate*<int, string, int, int, object?, FieldType, int, void> AcceptInput = &___AcceptInput;
		internal static delegate* unmanaged[Cdecl]<int, String192*, int, int, Variant256*, FieldType, int, void> __AcceptInput;
		private static void ___AcceptInput(int entityHandle, string inputName, int activatorHandle, int callerHandle, object? value, FieldType type, int outputId)
		{
			var __inputName = NativeMethods.ConstructString(inputName);
			var __value = NativeMethods.ConstructVariant(value);

			try {
				__AcceptInput(entityHandle, &__inputName, activatorHandle, callerHandle, &__value, type, outputId);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__inputName);
				NativeMethods.DestroyVariant(&__value);
			}
		}

		/// <summary>
		/// Creates a hook for when a game event is fired.
		/// </summary>
		/// <param name="name">The name of the event to hook.</param>
		/// <param name="pCallback">The callback function to call when the event is fired.</param>
		/// <param name="post">A boolean indicating whether the hook should be for a post event.</param>
		/// <returns>An integer indicating the result of the hook operation.</returns>
		/// <remarks>
		/// Callback EventCallback: Handles events triggered by the game event system. This function processes the event data, determines the necessary action, and optionally prevents event broadcasting.
		/// - Parameter name: The name of the event being handled. This string is used to identify the type or category of the event.
		/// - Parameter event: A 64-bit pointer to the event data structure. This pointer contains detailed information about the event being processed.
		/// - Parameter dontBroadcast: A boolean flag indicating whether the event should be prevented from being broadcasted to other listeners. Set to `true` to suppress broadcasting.
		/// - Returns: Indicates the result of the action execution. (int32)
		/// </remarks>

		internal static delegate*<string, EventCallback, Bool8, int> HookEvent = &___HookEvent;
		internal static delegate* unmanaged[Cdecl]<String192*, nint, Bool8, int> __HookEvent;
		private static int ___HookEvent(string name, EventCallback pCallback, Bool8 post)
		{
			int __retVal;
			var __name = NativeMethods.ConstructString(name);
			var __pCallback = Marshalling.GetFunctionPointerForDelegate(pCallback);

			try {
				__retVal = __HookEvent(&__name, __pCallback, post);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
			}
			return __retVal;
		}

		/// <summary>
		/// Removes a hook for when a game event is fired.
		/// </summary>
		/// <param name="name">The name of the event to unhook.</param>
		/// <param name="pCallback">The callback function to remove.</param>
		/// <param name="post">A boolean indicating whether the hook is for a post event.</param>
		/// <returns>An integer indicating the result of the unhook operation.</returns>
		/// <remarks>
		/// Callback EventCallback: Handles events triggered by the game event system. This function processes the event data, determines the necessary action, and optionally prevents event broadcasting.
		/// - Parameter name: The name of the event being handled. This string is used to identify the type or category of the event.
		/// - Parameter event: A 64-bit pointer to the event data structure. This pointer contains detailed information about the event being processed.
		/// - Parameter dontBroadcast: A boolean flag indicating whether the event should be prevented from being broadcasted to other listeners. Set to `true` to suppress broadcasting.
		/// - Returns: Indicates the result of the action execution. (int32)
		/// </remarks>

		internal static delegate*<string, EventCallback, Bool8, int> UnhookEvent = &___UnhookEvent;
		internal static delegate* unmanaged[Cdecl]<String192*, nint, Bool8, int> __UnhookEvent;
		private static int ___UnhookEvent(string name, EventCallback pCallback, Bool8 post)
		{
			int __retVal;
			var __name = NativeMethods.ConstructString(name);
			var __pCallback = Marshalling.GetFunctionPointerForDelegate(pCallback);

			try {
				__retVal = __UnhookEvent(&__name, __pCallback, post);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
			}
			return __retVal;
		}

		/// <summary>
		/// Creates a game event to be fired later.
		/// </summary>
		/// <param name="name">The name of the event to create.</param>
		/// <param name="force">A boolean indicating whether to force the creation of the event.</param>
		/// <returns>A pointer to the created EventInfo structure.</returns>

		internal static delegate*<string, Bool8, nint> CreateEvent = &___CreateEvent;
		internal static delegate* unmanaged[Cdecl]<String192*, Bool8, nint> __CreateEvent;
		private static nint ___CreateEvent(string name, Bool8 force)
		{
			nint __retVal;
			var __name = NativeMethods.ConstructString(name);

			try {
				__retVal = __CreateEvent(&__name, force);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
			}
			return __retVal;
		}

		/// <summary>
		/// Fires a game event.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="bDontBroadcast">A boolean indicating whether to broadcast the event.</param>

		internal static delegate*<nint, Bool8, void> FireEvent = &___FireEvent;
		internal static delegate* unmanaged[Cdecl]<nint, Bool8, void> __FireEvent;
		private static void ___FireEvent(nint pInfo, Bool8 bDontBroadcast)
		{
			__FireEvent(pInfo, bDontBroadcast);
		}

		/// <summary>
		/// Fires a game event to a specific client.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="clientIndex">The index of the client to fire the event to.</param>

		internal static delegate*<nint, int, void> FireEventToClient = &___FireEventToClient;
		internal static delegate* unmanaged[Cdecl]<nint, int, void> __FireEventToClient;
		private static void ___FireEventToClient(nint pInfo, int clientIndex)
		{
			__FireEventToClient(pInfo, clientIndex);
		}

		/// <summary>
		/// Cancels a previously created game event that has not been fired.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure of the event to cancel.</param>

		internal static delegate*<nint, void> CancelCreatedEvent = &___CancelCreatedEvent;
		internal static delegate* unmanaged[Cdecl]<nint, void> __CancelCreatedEvent;
		private static void ___CancelCreatedEvent(nint pInfo)
		{
			__CancelCreatedEvent(pInfo);
		}

		/// <summary>
		/// Retrieves the boolean value of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to retrieve the boolean value.</param>
		/// <returns>The boolean value associated with the key.</returns>

		internal static delegate*<nint, string, Bool8> GetEventBool = &___GetEventBool;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, Bool8> __GetEventBool;
		private static Bool8 ___GetEventBool(nint pInfo, string key)
		{
			Bool8 __retVal;
			var __key = NativeMethods.ConstructString(key);

			try {
				__retVal = __GetEventBool(pInfo, &__key);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the float value of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to retrieve the float value.</param>
		/// <returns>The float value associated with the key.</returns>

		internal static delegate*<nint, string, float> GetEventFloat = &___GetEventFloat;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, float> __GetEventFloat;
		private static float ___GetEventFloat(nint pInfo, string key)
		{
			float __retVal;
			var __key = NativeMethods.ConstructString(key);

			try {
				__retVal = __GetEventFloat(pInfo, &__key);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the integer value of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to retrieve the integer value.</param>
		/// <returns>The integer value associated with the key.</returns>

		internal static delegate*<nint, string, int> GetEventInt = &___GetEventInt;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, int> __GetEventInt;
		private static int ___GetEventInt(nint pInfo, string key)
		{
			int __retVal;
			var __key = NativeMethods.ConstructString(key);

			try {
				__retVal = __GetEventInt(pInfo, &__key);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the long integer value of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to retrieve the long integer value.</param>
		/// <returns>The long integer value associated with the key.</returns>

		internal static delegate*<nint, string, ulong> GetEventUInt64 = &___GetEventUInt64;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, ulong> __GetEventUInt64;
		private static ulong ___GetEventUInt64(nint pInfo, string key)
		{
			ulong __retVal;
			var __key = NativeMethods.ConstructString(key);

			try {
				__retVal = __GetEventUInt64(pInfo, &__key);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the string value of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to retrieve the string value.</param>
		/// <returns>A string where the result will be stored.</returns>

		internal static delegate*<nint, string, string> GetEventString = &___GetEventString;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192> __GetEventString;
		private static string ___GetEventString(nint pInfo, string key)
		{
			string __retVal;
			String192 __retVal_native;
			var __key = NativeMethods.ConstructString(key);

			try {
				__retVal_native = __GetEventString(pInfo, &__key);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
				NativeMethods.DestroyString(&__key);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the pointer value of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to retrieve the pointer value.</param>
		/// <returns>The pointer value associated with the key.</returns>

		internal static delegate*<nint, string, nint> GetEventPtr = &___GetEventPtr;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, nint> __GetEventPtr;
		private static nint ___GetEventPtr(nint pInfo, string key)
		{
			nint __retVal;
			var __key = NativeMethods.ConstructString(key);

			try {
				__retVal = __GetEventPtr(pInfo, &__key);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the player controller address of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to retrieve the player controller address.</param>
		/// <returns>A pointer to the player controller associated with the key.</returns>

		internal static delegate*<nint, string, nint> GetEventPlayerController = &___GetEventPlayerController;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, nint> __GetEventPlayerController;
		private static nint ___GetEventPlayerController(nint pInfo, string key)
		{
			nint __retVal;
			var __key = NativeMethods.ConstructString(key);

			try {
				__retVal = __GetEventPlayerController(pInfo, &__key);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the player index of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to retrieve the player index.</param>
		/// <returns>The player index associated with the key.</returns>

		internal static delegate*<nint, string, int> GetEventPlayerIndex = &___GetEventPlayerIndex;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, int> __GetEventPlayerIndex;
		private static int ___GetEventPlayerIndex(nint pInfo, string key)
		{
			int __retVal;
			var __key = NativeMethods.ConstructString(key);

			try {
				__retVal = __GetEventPlayerIndex(pInfo, &__key);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the player pawn address of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to retrieve the player pawn address.</param>
		/// <returns>A pointer to the player pawn associated with the key.</returns>

		internal static delegate*<nint, string, nint> GetEventPlayerPawn = &___GetEventPlayerPawn;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, nint> __GetEventPlayerPawn;
		private static nint ___GetEventPlayerPawn(nint pInfo, string key)
		{
			nint __retVal;
			var __key = NativeMethods.ConstructString(key);

			try {
				__retVal = __GetEventPlayerPawn(pInfo, &__key);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the entity address of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to retrieve the entity address.</param>
		/// <returns>A pointer to the entity associated with the key.</returns>

		internal static delegate*<nint, string, nint> GetEventEntity = &___GetEventEntity;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, nint> __GetEventEntity;
		private static nint ___GetEventEntity(nint pInfo, string key)
		{
			nint __retVal;
			var __key = NativeMethods.ConstructString(key);

			try {
				__retVal = __GetEventEntity(pInfo, &__key);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the entity index of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to retrieve the entity index.</param>
		/// <returns>The entity index associated with the key.</returns>

		internal static delegate*<nint, string, int> GetEventEntityIndex = &___GetEventEntityIndex;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, int> __GetEventEntityIndex;
		private static int ___GetEventEntityIndex(nint pInfo, string key)
		{
			int __retVal;
			var __key = NativeMethods.ConstructString(key);

			try {
				__retVal = __GetEventEntityIndex(pInfo, &__key);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the entity handle of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to retrieve the entity handle.</param>
		/// <returns>The entity handle associated with the key.</returns>

		internal static delegate*<nint, string, int> GetEventEntityHandle = &___GetEventEntityHandle;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, int> __GetEventEntityHandle;
		private static int ___GetEventEntityHandle(nint pInfo, string key)
		{
			int __retVal;
			var __key = NativeMethods.ConstructString(key);

			try {
				__retVal = __GetEventEntityHandle(pInfo, &__key);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the name of a game event.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <returns>A string where the result will be stored.</returns>

		internal static delegate*<nint, string> GetEventName = &___GetEventName;
		internal static delegate* unmanaged[Cdecl]<nint, String192> __GetEventName;
		private static string ___GetEventName(nint pInfo)
		{
			string __retVal;
			String192 __retVal_native;

			try {
				__retVal_native = __GetEventName(pInfo);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
			}
			return __retVal;
		}

		/// <summary>
		/// Sets the boolean value of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to set the boolean value.</param>
		/// <param name="value">The boolean value to set.</param>

		internal static delegate*<nint, string, Bool8, void> SetEventBool = &___SetEventBool;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, Bool8, void> __SetEventBool;
		private static void ___SetEventBool(nint pInfo, string key, Bool8 value)
		{
			var __key = NativeMethods.ConstructString(key);

			try {
				__SetEventBool(pInfo, &__key, value);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
		}

		/// <summary>
		/// Sets the floating point value of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to set the float value.</param>
		/// <param name="value">The float value to set.</param>

		internal static delegate*<nint, string, float, void> SetEventFloat = &___SetEventFloat;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, float, void> __SetEventFloat;
		private static void ___SetEventFloat(nint pInfo, string key, float value)
		{
			var __key = NativeMethods.ConstructString(key);

			try {
				__SetEventFloat(pInfo, &__key, value);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
		}

		/// <summary>
		/// Sets the integer value of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to set the integer value.</param>
		/// <param name="value">The integer value to set.</param>

		internal static delegate*<nint, string, int, void> SetEventInt = &___SetEventInt;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, int, void> __SetEventInt;
		private static void ___SetEventInt(nint pInfo, string key, int value)
		{
			var __key = NativeMethods.ConstructString(key);

			try {
				__SetEventInt(pInfo, &__key, value);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
		}

		/// <summary>
		/// Sets the long integer value of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to set the long integer value.</param>
		/// <param name="value">The long integer value to set.</param>

		internal static delegate*<nint, string, ulong, void> SetEventUInt64 = &___SetEventUInt64;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, ulong, void> __SetEventUInt64;
		private static void ___SetEventUInt64(nint pInfo, string key, ulong value)
		{
			var __key = NativeMethods.ConstructString(key);

			try {
				__SetEventUInt64(pInfo, &__key, value);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
		}

		/// <summary>
		/// Sets the string value of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to set the string value.</param>
		/// <param name="value">The string value to set.</param>

		internal static delegate*<nint, string, string, void> SetEventString = &___SetEventString;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192*, void> __SetEventString;
		private static void ___SetEventString(nint pInfo, string key, string value)
		{
			var __key = NativeMethods.ConstructString(key);
			var __value = NativeMethods.ConstructString(value);

			try {
				__SetEventString(pInfo, &__key, &__value);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
				NativeMethods.DestroyString(&__value);
			}
		}

		/// <summary>
		/// Sets the pointer value of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to set the pointer value.</param>
		/// <param name="value">The pointer value to set.</param>

		internal static delegate*<nint, string, nint, void> SetEventPtr = &___SetEventPtr;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, nint, void> __SetEventPtr;
		private static void ___SetEventPtr(nint pInfo, string key, nint value)
		{
			var __key = NativeMethods.ConstructString(key);

			try {
				__SetEventPtr(pInfo, &__key, value);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
		}

		/// <summary>
		/// Sets the player controller address of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to set the player controller address.</param>
		/// <param name="value">A pointer to the player controller to set.</param>

		internal static delegate*<nint, string, nint, void> SetEventPlayerController = &___SetEventPlayerController;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, nint, void> __SetEventPlayerController;
		private static void ___SetEventPlayerController(nint pInfo, string key, nint value)
		{
			var __key = NativeMethods.ConstructString(key);

			try {
				__SetEventPlayerController(pInfo, &__key, value);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
		}

		/// <summary>
		/// Sets the player index value of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to set the player index value.</param>
		/// <param name="value">The player index value to set.</param>

		internal static delegate*<nint, string, int, void> SetEventPlayerIndex = &___SetEventPlayerIndex;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, int, void> __SetEventPlayerIndex;
		private static void ___SetEventPlayerIndex(nint pInfo, string key, int value)
		{
			var __key = NativeMethods.ConstructString(key);

			try {
				__SetEventPlayerIndex(pInfo, &__key, value);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
		}

		/// <summary>
		/// Sets the entity address of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to set the entity address.</param>
		/// <param name="value">A pointer to the entity to set.</param>

		internal static delegate*<nint, string, nint, void> SetEventEntity = &___SetEventEntity;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, nint, void> __SetEventEntity;
		private static void ___SetEventEntity(nint pInfo, string key, nint value)
		{
			var __key = NativeMethods.ConstructString(key);

			try {
				__SetEventEntity(pInfo, &__key, value);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
		}

		/// <summary>
		/// Sets the entity index of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to set the entity index.</param>
		/// <param name="value">The entity index value to set.</param>

		internal static delegate*<nint, string, int, void> SetEventEntityIndex = &___SetEventEntityIndex;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, int, void> __SetEventEntityIndex;
		private static void ___SetEventEntityIndex(nint pInfo, string key, int value)
		{
			var __key = NativeMethods.ConstructString(key);

			try {
				__SetEventEntityIndex(pInfo, &__key, value);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
		}

		/// <summary>
		/// Sets the entity handle of a game event's key.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="key">The key for which to set the entity handle.</param>
		/// <param name="value">The entity handle value to set.</param>

		internal static delegate*<nint, string, int, void> SetEventEntityHandle = &___SetEventEntityHandle;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, int, void> __SetEventEntityHandle;
		private static void ___SetEventEntityHandle(nint pInfo, string key, int value)
		{
			var __key = NativeMethods.ConstructString(key);

			try {
				__SetEventEntityHandle(pInfo, &__key, value);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__key);
			}
		}

		/// <summary>
		/// Sets whether an event's broadcasting will be disabled or not.
		/// </summary>
		/// <param name="pInfo">A pointer to the EventInfo structure containing event data.</param>
		/// <param name="dontBroadcast">A boolean indicating whether to disable broadcasting.</param>

		internal static delegate*<nint, Bool8, void> SetEventBroadcast = &___SetEventBroadcast;
		internal static delegate* unmanaged[Cdecl]<nint, Bool8, void> __SetEventBroadcast;
		private static void ___SetEventBroadcast(nint pInfo, Bool8 dontBroadcast)
		{
			__SetEventBroadcast(pInfo, dontBroadcast);
		}

		/// <summary>
		/// Load game event descriptions from a file (e.g., "resource/gameevents.res").
		/// </summary>
		/// <param name="path">The path to the file containing event descriptions.</param>
		/// <param name="searchAll">A boolean indicating whether to search all paths for the file.</param>
		/// <returns>An integer indicating the result of the loading operation.</returns>

		internal static delegate*<string, Bool8, int> LoadEventsFromFile = &___LoadEventsFromFile;
		internal static delegate* unmanaged[Cdecl]<String192*, Bool8, int> __LoadEventsFromFile;
		private static int ___LoadEventsFromFile(string path, Bool8 searchAll)
		{
			int __retVal;
			var __path = NativeMethods.ConstructString(path);

			try {
				__retVal = __LoadEventsFromFile(&__path, searchAll);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__path);
			}
			return __retVal;
		}

		/// <summary>
		/// Closes a game configuration file.
		/// </summary>
		/// <param name="pGameConfig">A pointer to the game configuration to be closed.</param>

		internal static delegate*<nint, void> CloseGameConfigFile = &___CloseGameConfigFile;
		internal static delegate* unmanaged[Cdecl]<nint, void> __CloseGameConfigFile;
		private static void ___CloseGameConfigFile(nint pGameConfig)
		{
			__CloseGameConfigFile(pGameConfig);
		}

		/// <summary>
		/// Loads a game configuration file.
		/// </summary>
		/// <param name="file">The path to the game configuration file to be loaded.</param>
		/// <returns>A pointer to the loaded CGameConfig object, or nullptr if loading fails.</returns>

		internal static delegate*<string, nint> LoadGameConfigFile = &___LoadGameConfigFile;
		internal static delegate* unmanaged[Cdecl]<String192*, nint> __LoadGameConfigFile;
		private static nint ___LoadGameConfigFile(string file)
		{
			nint __retVal;
			var __file = NativeMethods.ConstructString(file);

			try {
				__retVal = __LoadGameConfigFile(&__file);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__file);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the path of a game configuration.
		/// </summary>
		/// <param name="pGameConfig">A pointer to the game configuration whose path is to be retrieved.</param>
		/// <returns>A string where the path will be stored.</returns>

		internal static delegate*<nint, string> GetGameConfigPath = &___GetGameConfigPath;
		internal static delegate* unmanaged[Cdecl]<nint, String192> __GetGameConfigPath;
		private static string ___GetGameConfigPath(nint pGameConfig)
		{
			string __retVal;
			String192 __retVal_native;

			try {
				__retVal_native = __GetGameConfigPath(pGameConfig);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves a library associated with the game configuration.
		/// </summary>
		/// <param name="pGameConfig">A pointer to the game configuration from which to retrieve the library.</param>
		/// <param name="name">The name of the library to be retrieved.</param>
		/// <returns>A string where the library will be stored.</returns>

		internal static delegate*<nint, string, string> GetGameConfigLibrary = &___GetGameConfigLibrary;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192> __GetGameConfigLibrary;
		private static string ___GetGameConfigLibrary(nint pGameConfig, string name)
		{
			string __retVal;
			String192 __retVal_native;
			var __name = NativeMethods.ConstructString(name);

			try {
				__retVal_native = __GetGameConfigLibrary(pGameConfig, &__name);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
				NativeMethods.DestroyString(&__name);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the signature associated with the game configuration.
		/// </summary>
		/// <param name="pGameConfig">A pointer to the game configuration from which to retrieve the signature.</param>
		/// <param name="name">The name of the signature to be retrieved.</param>
		/// <returns>A string where the signature will be stored.</returns>

		internal static delegate*<nint, string, string> GetGameConfigSignature = &___GetGameConfigSignature;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192> __GetGameConfigSignature;
		private static string ___GetGameConfigSignature(nint pGameConfig, string name)
		{
			string __retVal;
			String192 __retVal_native;
			var __name = NativeMethods.ConstructString(name);

			try {
				__retVal_native = __GetGameConfigSignature(pGameConfig, &__name);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
				NativeMethods.DestroyString(&__name);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves a symbol associated with the game configuration.
		/// </summary>
		/// <param name="pGameConfig">A pointer to the game configuration from which to retrieve the symbol.</param>
		/// <param name="name">The name of the symbol to be retrieved.</param>
		/// <returns>A string where the symbol will be stored.</returns>

		internal static delegate*<nint, string, string> GetGameConfigSymbol = &___GetGameConfigSymbol;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192> __GetGameConfigSymbol;
		private static string ___GetGameConfigSymbol(nint pGameConfig, string name)
		{
			string __retVal;
			String192 __retVal_native;
			var __name = NativeMethods.ConstructString(name);

			try {
				__retVal_native = __GetGameConfigSymbol(pGameConfig, &__name);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
				NativeMethods.DestroyString(&__name);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves a patch associated with the game configuration.
		/// </summary>
		/// <param name="pGameConfig">A pointer to the game configuration from which to retrieve the patch.</param>
		/// <param name="name">The name of the patch to be retrieved.</param>
		/// <returns>A string where the patch will be stored.</returns>

		internal static delegate*<nint, string, string> GetGameConfigPatch = &___GetGameConfigPatch;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192> __GetGameConfigPatch;
		private static string ___GetGameConfigPatch(nint pGameConfig, string name)
		{
			string __retVal;
			String192 __retVal_native;
			var __name = NativeMethods.ConstructString(name);

			try {
				__retVal_native = __GetGameConfigPatch(pGameConfig, &__name);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
				NativeMethods.DestroyString(&__name);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the offset associated with a name from the game configuration.
		/// </summary>
		/// <param name="pGameConfig">A pointer to the game configuration from which to retrieve the offset.</param>
		/// <param name="name">The name whose offset is to be retrieved.</param>
		/// <returns>The offset associated with the specified name.</returns>

		internal static delegate*<nint, string, int> GetGameConfigOffset = &___GetGameConfigOffset;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, int> __GetGameConfigOffset;
		private static int ___GetGameConfigOffset(nint pGameConfig, string name)
		{
			int __retVal;
			var __name = NativeMethods.ConstructString(name);

			try {
				__retVal = __GetGameConfigOffset(pGameConfig, &__name);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the address associated with a name from the game configuration.
		/// </summary>
		/// <param name="pGameConfig">A pointer to the game configuration from which to retrieve the address.</param>
		/// <param name="name">The name whose address is to be retrieved.</param>
		/// <returns>A pointer to the address associated with the specified name.</returns>

		internal static delegate*<nint, string, nint> GetGameConfigAddress = &___GetGameConfigAddress;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, nint> __GetGameConfigAddress;
		private static nint ___GetGameConfigAddress(nint pGameConfig, string name)
		{
			nint __retVal;
			var __name = NativeMethods.ConstructString(name);

			try {
				__retVal = __GetGameConfigAddress(pGameConfig, &__name);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves the memory signature associated with a name from the game configuration.
		/// </summary>
		/// <param name="pGameConfig">A pointer to the game configuration from which to retrieve the memory signature.</param>
		/// <param name="name">The name whose memory signature is to be resolved and retrieved.</param>
		/// <returns>A pointer to the memory signature associated with the specified name.</returns>

		internal static delegate*<nint, string, nint> GetGameConfigMemSig = &___GetGameConfigMemSig;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, nint> __GetGameConfigMemSig;
		private static nint ___GetGameConfigMemSig(nint pGameConfig, string name)
		{
			nint __retVal;
			var __name = NativeMethods.ConstructString(name);

			try {
				__retVal = __GetGameConfigMemSig(pGameConfig, &__name);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
			}
			return __retVal;
		}

		/// <summary>
		/// Registers a new logging channel with specified properties.
		/// </summary>
		/// <param name="name">The name of the logging channel.</param>
		/// <param name="iFlags">Flags associated with the logging channel.</param>
		/// <param name="verbosity">The verbosity level for the logging channel.</param>
		/// <param name="color">The color for messages logged to this channel.</param>
		/// <returns>The ID of the newly created logging channel.</returns>

		internal static delegate*<string, int, LoggingVerbosity, int, int> RegisterLoggingChannel = &___RegisterLoggingChannel;
		internal static delegate* unmanaged[Cdecl]<String192*, int, LoggingVerbosity, int, int> __RegisterLoggingChannel;
		private static int ___RegisterLoggingChannel(string name, int iFlags, LoggingVerbosity verbosity, int color)
		{
			int __retVal;
			var __name = NativeMethods.ConstructString(name);

			try {
				__retVal = __RegisterLoggingChannel(&__name, iFlags, verbosity, color);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
			}
			return __retVal;
		}

		/// <summary>
		/// Adds a tag to a specified logging channel.
		/// </summary>
		/// <param name="channelID">The ID of the logging channel to which the tag will be added.</param>
		/// <param name="tagName">The name of the tag to add to the channel.</param>

		internal static delegate*<int, string, void> AddLoggerTagToChannel = &___AddLoggerTagToChannel;
		internal static delegate* unmanaged[Cdecl]<int, String192*, void> __AddLoggerTagToChannel;
		private static void ___AddLoggerTagToChannel(int channelID, string tagName)
		{
			var __tagName = NativeMethods.ConstructString(tagName);

			try {
				__AddLoggerTagToChannel(channelID, &__tagName);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__tagName);
			}
		}

		/// <summary>
		/// Checks if a specified tag exists in a logging channel.
		/// </summary>
		/// <param name="channelID">The ID of the logging channel.</param>
		/// <param name="tag">The name of the tag to check for.</param>
		/// <returns>True if the tag exists in the channel, otherwise false.</returns>

		internal static delegate*<int, string, Bool8> HasLoggerTag = &___HasLoggerTag;
		internal static delegate* unmanaged[Cdecl]<int, String192*, Bool8> __HasLoggerTag;
		private static Bool8 ___HasLoggerTag(int channelID, string tag)
		{
			Bool8 __retVal;
			var __tag = NativeMethods.ConstructString(tag);

			try {
				__retVal = __HasLoggerTag(channelID, &__tag);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__tag);
			}
			return __retVal;
		}

		/// <summary>
		/// Checks if a logging channel is enabled based on severity.
		/// </summary>
		/// <param name="channelID">The ID of the logging channel.</param>
		/// <param name="severity">The severity of a logging operation.</param>
		/// <returns>True if the channel is enabled for the specified severity, otherwise false.</returns>

		internal static delegate*<int, LoggingSeverity, Bool8> IsLoggerChannelEnabledBySeverity = &___IsLoggerChannelEnabledBySeverity;
		internal static delegate* unmanaged[Cdecl]<int, LoggingSeverity, Bool8> __IsLoggerChannelEnabledBySeverity;
		private static Bool8 ___IsLoggerChannelEnabledBySeverity(int channelID, LoggingSeverity severity)
		{
			Bool8 __retVal = __IsLoggerChannelEnabledBySeverity(channelID, severity);
			return __retVal;
		}

		/// <summary>
		/// Checks if a logging channel is enabled based on verbosity.
		/// </summary>
		/// <param name="channelID">The ID of the logging channel.</param>
		/// <param name="verbosity">The verbosity level to check.</param>
		/// <returns>True if the channel is enabled for the specified verbosity, otherwise false.</returns>

		internal static delegate*<int, LoggingVerbosity, Bool8> IsLoggerChannelEnabledByVerbosity = &___IsLoggerChannelEnabledByVerbosity;
		internal static delegate* unmanaged[Cdecl]<int, LoggingVerbosity, Bool8> __IsLoggerChannelEnabledByVerbosity;
		private static Bool8 ___IsLoggerChannelEnabledByVerbosity(int channelID, LoggingVerbosity verbosity)
		{
			Bool8 __retVal = __IsLoggerChannelEnabledByVerbosity(channelID, verbosity);
			return __retVal;
		}

		/// <summary>
		/// Retrieves the verbosity level of a logging channel.
		/// </summary>
		/// <param name="channelID">The ID of the logging channel.</param>
		/// <returns>The verbosity level of the specified logging channel.</returns>

		internal static delegate*<int, int> GetLoggerChannelVerbosity = &___GetLoggerChannelVerbosity;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetLoggerChannelVerbosity;
		private static int ___GetLoggerChannelVerbosity(int channelID)
		{
			int __retVal = __GetLoggerChannelVerbosity(channelID);
			return __retVal;
		}

		/// <summary>
		/// Sets the verbosity level of a logging channel.
		/// </summary>
		/// <param name="channelID">The ID of the logging channel.</param>
		/// <param name="verbosity">The new verbosity level to set.</param>

		internal static delegate*<int, LoggingVerbosity, void> SetLoggerChannelVerbosity = &___SetLoggerChannelVerbosity;
		internal static delegate* unmanaged[Cdecl]<int, LoggingVerbosity, void> __SetLoggerChannelVerbosity;
		private static void ___SetLoggerChannelVerbosity(int channelID, LoggingVerbosity verbosity)
		{
			__SetLoggerChannelVerbosity(channelID, verbosity);
		}

		/// <summary>
		/// Sets the verbosity level of a logging channel by name.
		/// </summary>
		/// <param name="channelID">The ID of the logging channel.</param>
		/// <param name="name">The name of the logging channel.</param>
		/// <param name="verbosity">The new verbosity level to set.</param>

		internal static delegate*<int, string, LoggingVerbosity, void> SetLoggerChannelVerbosityByName = &___SetLoggerChannelVerbosityByName;
		internal static delegate* unmanaged[Cdecl]<int, String192*, LoggingVerbosity, void> __SetLoggerChannelVerbosityByName;
		private static void ___SetLoggerChannelVerbosityByName(int channelID, string name, LoggingVerbosity verbosity)
		{
			var __name = NativeMethods.ConstructString(name);

			try {
				__SetLoggerChannelVerbosityByName(channelID, &__name, verbosity);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__name);
			}
		}

		/// <summary>
		/// Sets the verbosity level of a logging channel by tag.
		/// </summary>
		/// <param name="channelID">The ID of the logging channel.</param>
		/// <param name="tag">The name of the tag.</param>
		/// <param name="verbosity">The new verbosity level to set.</param>

		internal static delegate*<int, string, LoggingVerbosity, void> SetLoggerChannelVerbosityByTag = &___SetLoggerChannelVerbosityByTag;
		internal static delegate* unmanaged[Cdecl]<int, String192*, LoggingVerbosity, void> __SetLoggerChannelVerbosityByTag;
		private static void ___SetLoggerChannelVerbosityByTag(int channelID, string tag, LoggingVerbosity verbosity)
		{
			var __tag = NativeMethods.ConstructString(tag);

			try {
				__SetLoggerChannelVerbosityByTag(channelID, &__tag, verbosity);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__tag);
			}
		}

		/// <summary>
		/// Retrieves the color setting of a logging channel.
		/// </summary>
		/// <param name="channelID">The ID of the logging channel.</param>
		/// <returns>The color value of the specified logging channel.</returns>

		internal static delegate*<int, int> GetLoggerChannelColor = &___GetLoggerChannelColor;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetLoggerChannelColor;
		private static int ___GetLoggerChannelColor(int channelID)
		{
			int __retVal = __GetLoggerChannelColor(channelID);
			return __retVal;
		}

		/// <summary>
		/// Sets the color setting of a logging channel.
		/// </summary>
		/// <param name="channelID">The ID of the logging channel.</param>
		/// <param name="color">The new color value to set for the channel.</param>

		internal static delegate*<int, int, void> SetLoggerChannelColor = &___SetLoggerChannelColor;
		internal static delegate* unmanaged[Cdecl]<int, int, void> __SetLoggerChannelColor;
		private static void ___SetLoggerChannelColor(int channelID, int color)
		{
			__SetLoggerChannelColor(channelID, color);
		}

		/// <summary>
		/// Retrieves the flags of a logging channel.
		/// </summary>
		/// <param name="channelID">The ID of the logging channel.</param>
		/// <returns>The flags of the specified logging channel.</returns>

		internal static delegate*<int, int> GetLoggerChannelFlags = &___GetLoggerChannelFlags;
		internal static delegate* unmanaged[Cdecl]<int, int> __GetLoggerChannelFlags;
		private static int ___GetLoggerChannelFlags(int channelID)
		{
			int __retVal = __GetLoggerChannelFlags(channelID);
			return __retVal;
		}

		/// <summary>
		/// Sets the flags of a logging channel.
		/// </summary>
		/// <param name="channelID">The ID of the logging channel.</param>
		/// <param name="eFlags">The new flags to set for the channel.</param>

		internal static delegate*<int, LoggingChannelFlags, void> SetLoggerChannelFlags = &___SetLoggerChannelFlags;
		internal static delegate* unmanaged[Cdecl]<int, LoggingChannelFlags, void> __SetLoggerChannelFlags;
		private static void ___SetLoggerChannelFlags(int channelID, LoggingChannelFlags eFlags)
		{
			__SetLoggerChannelFlags(channelID, eFlags);
		}

		/// <summary>
		/// Logs a message to a specified channel with a severity level.
		/// </summary>
		/// <param name="channelID">The ID of the logging channel.</param>
		/// <param name="severity">The severity level for the log message.</param>
		/// <param name="message">The message to log.</param>
		/// <returns>An integer indicating the result of the logging operation.</returns>

		internal static delegate*<int, LoggingSeverity, string, int> Log = &___Log;
		internal static delegate* unmanaged[Cdecl]<int, LoggingSeverity, String192*, int> __Log;
		private static int ___Log(int channelID, LoggingSeverity severity, string message)
		{
			int __retVal;
			var __message = NativeMethods.ConstructString(message);

			try {
				__retVal = __Log(channelID, severity, &__message);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__message);
			}
			return __retVal;
		}

		/// <summary>
		/// Logs a colored message to a specified channel with a severity level.
		/// </summary>
		/// <param name="channelID">The ID of the logging channel.</param>
		/// <param name="severity">The severity level for the log message.</param>
		/// <param name="color">The color for the log message.</param>
		/// <param name="message">The message to log.</param>
		/// <returns>An integer indicating the result of the logging operation.</returns>

		internal static delegate*<int, LoggingSeverity, int, string, int> LogColored = &___LogColored;
		internal static delegate* unmanaged[Cdecl]<int, LoggingSeverity, int, String192*, int> __LogColored;
		private static int ___LogColored(int channelID, LoggingSeverity severity, int color, string message)
		{
			int __retVal;
			var __message = NativeMethods.ConstructString(message);

			try {
				__retVal = __LogColored(channelID, severity, color, &__message);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__message);
			}
			return __retVal;
		}

		/// <summary>
		/// Logs a detailed message to a specified channel, including source code info.
		/// </summary>
		/// <param name="channelID">The ID of the logging channel.</param>
		/// <param name="severity">The severity level for the log message.</param>
		/// <param name="file">The file name where the log call occurred.</param>
		/// <param name="line">The line number where the log call occurred.</param>
		/// <param name="function">The name of the function where the log call occurred.</param>
		/// <param name="message">The message to log.</param>
		/// <returns>An integer indicating the result of the logging operation.</returns>

		internal static delegate*<int, LoggingSeverity, string, int, string, string, int> LogFull = &___LogFull;
		internal static delegate* unmanaged[Cdecl]<int, LoggingSeverity, String192*, int, String192*, String192*, int> __LogFull;
		private static int ___LogFull(int channelID, LoggingSeverity severity, string file, int line, string function, string message)
		{
			int __retVal;
			var __file = NativeMethods.ConstructString(file);
			var __function = NativeMethods.ConstructString(function);
			var __message = NativeMethods.ConstructString(message);

			try {
				__retVal = __LogFull(channelID, severity, &__file, line, &__function, &__message);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__file);
				NativeMethods.DestroyString(&__function);
				NativeMethods.DestroyString(&__message);
			}
			return __retVal;
		}

		/// <summary>
		/// Logs a detailed colored message to a specified channel, including source code info.
		/// </summary>
		/// <param name="channelID">The ID of the logging channel.</param>
		/// <param name="severity">The severity level for the log message.</param>
		/// <param name="file">The file name where the log call occurred.</param>
		/// <param name="line">The line number where the log call occurred.</param>
		/// <param name="function">The name of the function where the log call occurred.</param>
		/// <param name="color">The color for the log message.</param>
		/// <param name="message">The message to log.</param>
		/// <returns>An integer indicating the result of the logging operation.</returns>

		internal static delegate*<int, LoggingSeverity, string, int, string, int, string, int> LogFullColored = &___LogFullColored;
		internal static delegate* unmanaged[Cdecl]<int, LoggingSeverity, String192*, int, String192*, int, String192*, int> __LogFullColored;
		private static int ___LogFullColored(int channelID, LoggingSeverity severity, string file, int line, string function, int color, string message)
		{
			int __retVal;
			var __file = NativeMethods.ConstructString(file);
			var __function = NativeMethods.ConstructString(function);
			var __message = NativeMethods.ConstructString(message);

			try {
				__retVal = __LogFullColored(channelID, severity, &__file, line, &__function, color, &__message);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__file);
				NativeMethods.DestroyString(&__function);
				NativeMethods.DestroyString(&__message);
			}
			return __retVal;
		}

		/// <summary>
		/// Get the offset of a member in a given schema class.
		/// </summary>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the member whose offset is to be retrieved.</param>
		/// <returns>The offset of the member in the class.</returns>

		internal static delegate*<string, string, int> GetSchemaOffset = &___GetSchemaOffset;
		internal static delegate* unmanaged[Cdecl]<String192*, String192*, int> __GetSchemaOffset;
		private static int ___GetSchemaOffset(string className, string memberName)
		{
			int __retVal;
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__retVal = __GetSchemaOffset(&__className, &__memberName);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
			return __retVal;
		}

		/// <summary>
		/// Get the offset of a chain in a given schema class.
		/// </summary>
		/// <param name="className">The name of the class.</param>
		/// <returns>The offset of the chain entity in the class.</returns>

		internal static delegate*<string, int> GetSchemaChainOffset = &___GetSchemaChainOffset;
		internal static delegate* unmanaged[Cdecl]<String192*, int> __GetSchemaChainOffset;
		private static int ___GetSchemaChainOffset(string className)
		{
			int __retVal;
			var __className = NativeMethods.ConstructString(className);

			try {
				__retVal = __GetSchemaChainOffset(&__className);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
			}
			return __retVal;
		}

		/// <summary>
		/// Check if a schema field is networked.
		/// </summary>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the member to check.</param>
		/// <returns>True if the member is networked, false otherwise.</returns>

		internal static delegate*<string, string, Bool8> IsSchemaFieldNetworked = &___IsSchemaFieldNetworked;
		internal static delegate* unmanaged[Cdecl]<String192*, String192*, Bool8> __IsSchemaFieldNetworked;
		private static Bool8 ___IsSchemaFieldNetworked(string className, string memberName)
		{
			Bool8 __retVal;
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__retVal = __IsSchemaFieldNetworked(&__className, &__memberName);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
			return __retVal;
		}

		/// <summary>
		/// Get the size of a schema class.
		/// </summary>
		/// <param name="className">The name of the class.</param>
		/// <returns>The size of the class in bytes, or -1 if the class is not found.</returns>

		internal static delegate*<string, int> GetSchemaClassSize = &___GetSchemaClassSize;
		internal static delegate* unmanaged[Cdecl]<String192*, int> __GetSchemaClassSize;
		private static int ___GetSchemaClassSize(string className)
		{
			int __retVal;
			var __className = NativeMethods.ConstructString(className);

			try {
				__retVal = __GetSchemaClassSize(&__className);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
			}
			return __retVal;
		}

		/// <summary>
		/// Peeks into an entity's object schema and retrieves the integer value at the given offset.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <param name="size">Number of bytes to write (valid values are 1, 2, 4 or 8).</param>
		/// <returns>The integer value at the given memory location.</returns>

		internal static delegate*<nint, int, int, long> GetEntData2 = &___GetEntData2;
		internal static delegate* unmanaged[Cdecl]<nint, int, int, long> __GetEntData2;
		private static long ___GetEntData2(nint entity, int offset, int size)
		{
			long __retVal = __GetEntData2(entity, offset, size);
			return __retVal;
		}

		/// <summary>
		/// Peeks into an entity's object data and sets the integer value at the given offset.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <param name="value">The integer value to set.</param>
		/// <param name="size">Number of bytes to write (valid values are 1, 2, 4 or 8).</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="chainOffset">The offset of the chain entity in the class.</param>

		internal static delegate*<nint, int, long, int, Bool8, int, void> SetEntData2 = &___SetEntData2;
		internal static delegate* unmanaged[Cdecl]<nint, int, long, int, Bool8, int, void> __SetEntData2;
		private static void ___SetEntData2(nint entity, int offset, long value, int size, Bool8 changeState, int chainOffset)
		{
			__SetEntData2(entity, offset, value, size, changeState, chainOffset);
		}

		/// <summary>
		/// Peeks into an entity's object schema and retrieves the float value at the given offset.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <param name="size">Number of bytes to write (valid values are 1, 2, 4 or 8).</param>
		/// <returns>The float value at the given memory location.</returns>

		internal static delegate*<nint, int, int, double> GetEntDataFloat2 = &___GetEntDataFloat2;
		internal static delegate* unmanaged[Cdecl]<nint, int, int, double> __GetEntDataFloat2;
		private static double ___GetEntDataFloat2(nint entity, int offset, int size)
		{
			double __retVal = __GetEntDataFloat2(entity, offset, size);
			return __retVal;
		}

		/// <summary>
		/// Peeks into an entity's object data and sets the float value at the given offset.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <param name="value">The float value to set.</param>
		/// <param name="size">Number of bytes to write (valid values are 1, 2, 4 or 8).</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="chainOffset">The offset of the chain entity in the class.</param>

		internal static delegate*<nint, int, double, int, Bool8, int, void> SetEntDataFloat2 = &___SetEntDataFloat2;
		internal static delegate* unmanaged[Cdecl]<nint, int, double, int, Bool8, int, void> __SetEntDataFloat2;
		private static void ___SetEntDataFloat2(nint entity, int offset, double value, int size, Bool8 changeState, int chainOffset)
		{
			__SetEntDataFloat2(entity, offset, value, size, changeState, chainOffset);
		}

		/// <summary>
		/// Peeks into an entity's object schema and retrieves the string value at the given offset.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <returns>The string value at the given memory location.</returns>

		internal static delegate*<nint, int, string> GetEntDataString2 = &___GetEntDataString2;
		internal static delegate* unmanaged[Cdecl]<nint, int, String192> __GetEntDataString2;
		private static string ___GetEntDataString2(nint entity, int offset)
		{
			string __retVal;
			String192 __retVal_native;

			try {
				__retVal_native = __GetEntDataString2(entity, offset);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
			}
			return __retVal;
		}

		/// <summary>
		/// Peeks into an entity's object data and sets the string at the given offset.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <param name="value">The string value to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="chainOffset">The offset of the chain entity in the class.</param>

		internal static delegate*<nint, int, string, Bool8, int, void> SetEntDataString2 = &___SetEntDataString2;
		internal static delegate* unmanaged[Cdecl]<nint, int, String192*, Bool8, int, void> __SetEntDataString2;
		private static void ___SetEntDataString2(nint entity, int offset, string value, Bool8 changeState, int chainOffset)
		{
			var __value = NativeMethods.ConstructString(value);

			try {
				__SetEntDataString2(entity, offset, &__value, changeState, chainOffset);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__value);
			}
		}

		/// <summary>
		/// Peeks into an entity's object schema and retrieves the vector value at the given offset.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <returns>The vector value at the given memory location.</returns>

		internal static delegate*<nint, int, Vector3> GetEntDataVector2 = &___GetEntDataVector2;
		internal static delegate* unmanaged[Cdecl]<nint, int, Vector3> __GetEntDataVector2;
		private static Vector3 ___GetEntDataVector2(nint entity, int offset)
		{
			Vector3 __retVal = __GetEntDataVector2(entity, offset);
			return __retVal;
		}

		/// <summary>
		/// Peeks into an entity's object data and sets the vector at the given offset.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <param name="value">The vector value to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="chainOffset">The offset of the chain entity in the class.</param>

		internal static delegate*<nint, int, Vector3, Bool8, int, void> SetEntDataVector2 = &___SetEntDataVector2;
		internal static delegate* unmanaged[Cdecl]<nint, int, Vector3*, Bool8, int, void> __SetEntDataVector2;
		private static void ___SetEntDataVector2(nint entity, int offset, Vector3 value, Bool8 changeState, int chainOffset)
		{
			__SetEntDataVector2(entity, offset, &value, changeState, chainOffset);
		}

		/// <summary>
		/// Peeks into an entity's object data and retrieves the entity handle at the given offset.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <returns>The entity handle at the given memory location.</returns>

		internal static delegate*<nint, int, int> GetEntDataEnt2 = &___GetEntDataEnt2;
		internal static delegate* unmanaged[Cdecl]<nint, int, int> __GetEntDataEnt2;
		private static int ___GetEntDataEnt2(nint entity, int offset)
		{
			int __retVal = __GetEntDataEnt2(entity, offset);
			return __retVal;
		}

		/// <summary>
		/// Peeks into an entity's object data and sets the entity handle at the given offset.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <param name="value">The entity handle to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="chainOffset">The offset of the chain entity in the class.</param>

		internal static delegate*<nint, int, int, Bool8, int, void> SetEntDataEnt2 = &___SetEntDataEnt2;
		internal static delegate* unmanaged[Cdecl]<nint, int, int, Bool8, int, void> __SetEntDataEnt2;
		private static void ___SetEntDataEnt2(nint entity, int offset, int value, Bool8 changeState, int chainOffset)
		{
			__SetEntDataEnt2(entity, offset, value, changeState, chainOffset);
		}

		/// <summary>
		/// Updates the networked state of a schema field for a given entity pointer.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <param name="chainOffset">The offset of the chain entity in the class.</param>

		internal static delegate*<nint, int, int, void> ChangeEntityState2 = &___ChangeEntityState2;
		internal static delegate* unmanaged[Cdecl]<nint, int, int, void> __ChangeEntityState2;
		private static void ___ChangeEntityState2(nint entity, int offset, int chainOffset)
		{
			__ChangeEntityState2(entity, offset, chainOffset);
		}

		/// <summary>
		/// Peeks into an entity's object schema and retrieves the integer value at the given offset.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <param name="size">Number of bytes to write (valid values are 1, 2, 4 or 8).</param>
		/// <returns>The integer value at the given memory location.</returns>

		internal static delegate*<int, int, int, long> GetEntData = &___GetEntData;
		internal static delegate* unmanaged[Cdecl]<int, int, int, long> __GetEntData;
		private static long ___GetEntData(int entityHandle, int offset, int size)
		{
			long __retVal = __GetEntData(entityHandle, offset, size);
			return __retVal;
		}

		/// <summary>
		/// Peeks into an entity's object data and sets the integer value at the given offset.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <param name="value">The integer value to set.</param>
		/// <param name="size">Number of bytes to write (valid values are 1, 2, 4 or 8).</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="chainOffset">The offset of the chain entity in the class.</param>

		internal static delegate*<int, int, long, int, Bool8, int, void> SetEntData = &___SetEntData;
		internal static delegate* unmanaged[Cdecl]<int, int, long, int, Bool8, int, void> __SetEntData;
		private static void ___SetEntData(int entityHandle, int offset, long value, int size, Bool8 changeState, int chainOffset)
		{
			__SetEntData(entityHandle, offset, value, size, changeState, chainOffset);
		}

		/// <summary>
		/// Peeks into an entity's object schema and retrieves the float value at the given offset.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <param name="size">Number of bytes to write (valid values are 1, 2, 4 or 8).</param>
		/// <returns>The float value at the given memory location.</returns>

		internal static delegate*<int, int, int, double> GetEntDataFloat = &___GetEntDataFloat;
		internal static delegate* unmanaged[Cdecl]<int, int, int, double> __GetEntDataFloat;
		private static double ___GetEntDataFloat(int entityHandle, int offset, int size)
		{
			double __retVal = __GetEntDataFloat(entityHandle, offset, size);
			return __retVal;
		}

		/// <summary>
		/// Peeks into an entity's object data and sets the float value at the given offset.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <param name="value">The float value to set.</param>
		/// <param name="size">Number of bytes to write (valid values are 1, 2, 4 or 8).</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="chainOffset">The offset of the chain entity in the class.</param>

		internal static delegate*<int, int, double, int, Bool8, int, void> SetEntDataFloat = &___SetEntDataFloat;
		internal static delegate* unmanaged[Cdecl]<int, int, double, int, Bool8, int, void> __SetEntDataFloat;
		private static void ___SetEntDataFloat(int entityHandle, int offset, double value, int size, Bool8 changeState, int chainOffset)
		{
			__SetEntDataFloat(entityHandle, offset, value, size, changeState, chainOffset);
		}

		/// <summary>
		/// Peeks into an entity's object schema and retrieves the string value at the given offset.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <returns>The string value at the given memory location.</returns>

		internal static delegate*<int, int, string> GetEntDataString = &___GetEntDataString;
		internal static delegate* unmanaged[Cdecl]<int, int, String192> __GetEntDataString;
		private static string ___GetEntDataString(int entityHandle, int offset)
		{
			string __retVal;
			String192 __retVal_native;

			try {
				__retVal_native = __GetEntDataString(entityHandle, offset);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
			}
			return __retVal;
		}

		/// <summary>
		/// Peeks into an entity's object data and sets the string at the given offset.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <param name="value">The string value to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="chainOffset">The offset of the chain entity in the class.</param>

		internal static delegate*<int, int, string, Bool8, int, void> SetEntDataString = &___SetEntDataString;
		internal static delegate* unmanaged[Cdecl]<int, int, String192*, Bool8, int, void> __SetEntDataString;
		private static void ___SetEntDataString(int entityHandle, int offset, string value, Bool8 changeState, int chainOffset)
		{
			var __value = NativeMethods.ConstructString(value);

			try {
				__SetEntDataString(entityHandle, offset, &__value, changeState, chainOffset);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__value);
			}
		}

		/// <summary>
		/// Peeks into an entity's object schema and retrieves the vector value at the given offset.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <returns>The vector value at the given memory location.</returns>

		internal static delegate*<int, int, Vector3> GetEntDataVector = &___GetEntDataVector;
		internal static delegate* unmanaged[Cdecl]<int, int, Vector3> __GetEntDataVector;
		private static Vector3 ___GetEntDataVector(int entityHandle, int offset)
		{
			Vector3 __retVal = __GetEntDataVector(entityHandle, offset);
			return __retVal;
		}

		/// <summary>
		/// Peeks into an entity's object data and sets the vector at the given offset.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <param name="value">The vector value to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="chainOffset">The offset of the chain entity in the class.</param>

		internal static delegate*<int, int, Vector3, Bool8, int, void> SetEntDataVector = &___SetEntDataVector;
		internal static delegate* unmanaged[Cdecl]<int, int, Vector3*, Bool8, int, void> __SetEntDataVector;
		private static void ___SetEntDataVector(int entityHandle, int offset, Vector3 value, Bool8 changeState, int chainOffset)
		{
			__SetEntDataVector(entityHandle, offset, &value, changeState, chainOffset);
		}

		/// <summary>
		/// Peeks into an entity's object data and retrieves the entity handle at the given offset.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <returns>The entity handle at the given memory location.</returns>

		internal static delegate*<int, int, int> GetEntDataEnt = &___GetEntDataEnt;
		internal static delegate* unmanaged[Cdecl]<int, int, int> __GetEntDataEnt;
		private static int ___GetEntDataEnt(int entityHandle, int offset)
		{
			int __retVal = __GetEntDataEnt(entityHandle, offset);
			return __retVal;
		}

		/// <summary>
		/// Peeks into an entity's object data and sets the entity handle at the given offset.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <param name="value">The entity handle to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="chainOffset">The offset of the chain entity in the class.</param>

		internal static delegate*<int, int, int, Bool8, int, void> SetEntDataEnt = &___SetEntDataEnt;
		internal static delegate* unmanaged[Cdecl]<int, int, int, Bool8, int, void> __SetEntDataEnt;
		private static void ___SetEntDataEnt(int entityHandle, int offset, int value, Bool8 changeState, int chainOffset)
		{
			__SetEntDataEnt(entityHandle, offset, value, changeState, chainOffset);
		}

		/// <summary>
		/// Updates the networked state of a schema field for a given entity handle.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="offset">The offset of the schema to use.</param>
		/// <param name="chainOffset">The offset of the chain entity in the class.</param>

		internal static delegate*<int, int, int, void> ChangeEntityState = &___ChangeEntityState;
		internal static delegate* unmanaged[Cdecl]<int, int, int, void> __ChangeEntityState;
		private static void ___ChangeEntityState(int entityHandle, int offset, int chainOffset)
		{
			__ChangeEntityState(entityHandle, offset, chainOffset);
		}

		/// <summary>
		/// Retrieves the count of values that an entity schema's array can store.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <returns>Size of array (in elements) or 0 if schema is not an array.</returns>

		internal static delegate*<nint, string, string, int> GetEntSchemaArraySize2 = &___GetEntSchemaArraySize2;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192*, int> __GetEntSchemaArraySize2;
		private static int ___GetEntSchemaArraySize2(nint entity, string className, string memberName)
		{
			int __retVal;
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__retVal = __GetEntSchemaArraySize2(entity, &__className, &__memberName);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves an integer value from an entity's schema.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>
		/// <returns>An integer value at the given schema offset.</returns>

		internal static delegate*<nint, string, string, int, long> GetEntSchema2 = &___GetEntSchema2;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192*, int, long> __GetEntSchema2;
		private static long ___GetEntSchema2(nint entity, string className, string memberName, int element)
		{
			long __retVal;
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__retVal = __GetEntSchema2(entity, &__className, &__memberName, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
			return __retVal;
		}

		/// <summary>
		/// Sets an integer value in an entity's schema.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="value">The integer value to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>

		internal static delegate*<nint, string, string, long, Bool8, int, void> SetEntSchema2 = &___SetEntSchema2;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192*, long, Bool8, int, void> __SetEntSchema2;
		private static void ___SetEntSchema2(nint entity, string className, string memberName, long value, Bool8 changeState, int element)
		{
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__SetEntSchema2(entity, &__className, &__memberName, value, changeState, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
		}

		/// <summary>
		/// Retrieves a float value from an entity's schema.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>
		/// <returns>A float value at the given schema offset.</returns>

		internal static delegate*<nint, string, string, int, double> GetEntSchemaFloat2 = &___GetEntSchemaFloat2;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192*, int, double> __GetEntSchemaFloat2;
		private static double ___GetEntSchemaFloat2(nint entity, string className, string memberName, int element)
		{
			double __retVal;
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__retVal = __GetEntSchemaFloat2(entity, &__className, &__memberName, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
			return __retVal;
		}

		/// <summary>
		/// Sets a float value in an entity's schema.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="value">The float value to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>

		internal static delegate*<nint, string, string, double, Bool8, int, void> SetEntSchemaFloat2 = &___SetEntSchemaFloat2;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192*, double, Bool8, int, void> __SetEntSchemaFloat2;
		private static void ___SetEntSchemaFloat2(nint entity, string className, string memberName, double value, Bool8 changeState, int element)
		{
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__SetEntSchemaFloat2(entity, &__className, &__memberName, value, changeState, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
		}

		/// <summary>
		/// Retrieves a string value from an entity's schema.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>
		/// <returns>A string value at the given schema offset.</returns>

		internal static delegate*<nint, string, string, int, string> GetEntSchemaString2 = &___GetEntSchemaString2;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192*, int, String192> __GetEntSchemaString2;
		private static string ___GetEntSchemaString2(nint entity, string className, string memberName, int element)
		{
			string __retVal;
			String192 __retVal_native;
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__retVal_native = __GetEntSchemaString2(entity, &__className, &__memberName, element);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
			return __retVal;
		}

		/// <summary>
		/// Sets a string value in an entity's schema.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="value">The string value to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>

		internal static delegate*<nint, string, string, string, Bool8, int, void> SetEntSchemaString2 = &___SetEntSchemaString2;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192*, String192*, Bool8, int, void> __SetEntSchemaString2;
		private static void ___SetEntSchemaString2(nint entity, string className, string memberName, string value, Bool8 changeState, int element)
		{
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);
			var __value = NativeMethods.ConstructString(value);

			try {
				__SetEntSchemaString2(entity, &__className, &__memberName, &__value, changeState, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
				NativeMethods.DestroyString(&__value);
			}
		}

		/// <summary>
		/// Retrieves a vector value from an entity's schema.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>
		/// <returns>A vector value at the given schema offset.</returns>

		internal static delegate*<nint, string, string, int, Vector3> GetEntSchemaVector3D2 = &___GetEntSchemaVector3D2;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192*, int, Vector3> __GetEntSchemaVector3D2;
		private static Vector3 ___GetEntSchemaVector3D2(nint entity, string className, string memberName, int element)
		{
			Vector3 __retVal;
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__retVal = __GetEntSchemaVector3D2(entity, &__className, &__memberName, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
			return __retVal;
		}

		/// <summary>
		/// Sets a vector value in an entity's schema.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="value">The vector value to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>

		internal static delegate*<nint, string, string, Vector3, Bool8, int, void> SetEntSchemaVector3D2 = &___SetEntSchemaVector3D2;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192*, Vector3*, Bool8, int, void> __SetEntSchemaVector3D2;
		private static void ___SetEntSchemaVector3D2(nint entity, string className, string memberName, Vector3 value, Bool8 changeState, int element)
		{
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__SetEntSchemaVector3D2(entity, &__className, &__memberName, &value, changeState, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
		}

		/// <summary>
		/// Retrieves a vector value from an entity's schema.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>
		/// <returns>A vector value at the given schema offset.</returns>

		internal static delegate*<nint, string, string, int, Vector2> GetEntSchemaVector2D2 = &___GetEntSchemaVector2D2;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192*, int, Vector2> __GetEntSchemaVector2D2;
		private static Vector2 ___GetEntSchemaVector2D2(nint entity, string className, string memberName, int element)
		{
			Vector2 __retVal;
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__retVal = __GetEntSchemaVector2D2(entity, &__className, &__memberName, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
			return __retVal;
		}

		/// <summary>
		/// Sets a vector value in an entity's schema.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="value">The vector value to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>

		internal static delegate*<nint, string, string, Vector2, Bool8, int, void> SetEntSchemaVector2D2 = &___SetEntSchemaVector2D2;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192*, Vector2*, Bool8, int, void> __SetEntSchemaVector2D2;
		private static void ___SetEntSchemaVector2D2(nint entity, string className, string memberName, Vector2 value, Bool8 changeState, int element)
		{
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__SetEntSchemaVector2D2(entity, &__className, &__memberName, &value, changeState, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
		}

		/// <summary>
		/// Retrieves a vector value from an entity's schema.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>
		/// <returns>A vector value at the given schema offset.</returns>

		internal static delegate*<nint, string, string, int, Vector4> GetEntSchemaVector4D2 = &___GetEntSchemaVector4D2;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192*, int, Vector4> __GetEntSchemaVector4D2;
		private static Vector4 ___GetEntSchemaVector4D2(nint entity, string className, string memberName, int element)
		{
			Vector4 __retVal;
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__retVal = __GetEntSchemaVector4D2(entity, &__className, &__memberName, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
			return __retVal;
		}

		/// <summary>
		/// Sets a vector value in an entity's schema.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="value">The vector value to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>

		internal static delegate*<nint, string, string, Vector4, Bool8, int, void> SetEntSchemaVector4D2 = &___SetEntSchemaVector4D2;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192*, Vector4*, Bool8, int, void> __SetEntSchemaVector4D2;
		private static void ___SetEntSchemaVector4D2(nint entity, string className, string memberName, Vector4 value, Bool8 changeState, int element)
		{
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__SetEntSchemaVector4D2(entity, &__className, &__memberName, &value, changeState, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
		}

		/// <summary>
		/// Retrieves an entity handle from an entity's schema.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>
		/// <returns>A string value at the given schema offset.</returns>

		internal static delegate*<nint, string, string, int, int> GetEntSchemaEnt2 = &___GetEntSchemaEnt2;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192*, int, int> __GetEntSchemaEnt2;
		private static int ___GetEntSchemaEnt2(nint entity, string className, string memberName, int element)
		{
			int __retVal;
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__retVal = __GetEntSchemaEnt2(entity, &__className, &__memberName, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
			return __retVal;
		}

		/// <summary>
		/// Sets an entity handle in an entity's schema.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="value">The entity handle to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>

		internal static delegate*<nint, string, string, int, Bool8, int, void> SetEntSchemaEnt2 = &___SetEntSchemaEnt2;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192*, int, Bool8, int, void> __SetEntSchemaEnt2;
		private static void ___SetEntSchemaEnt2(nint entity, string className, string memberName, int value, Bool8 changeState, int element)
		{
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__SetEntSchemaEnt2(entity, &__className, &__memberName, value, changeState, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
		}

		/// <summary>
		/// Updates the networked state of a schema field for a given entity pointer.
		/// </summary>
		/// <param name="entity">Pointer to the instance of the class where the value is to be set.</param>
		/// <param name="className">The name of the class that contains the member.</param>
		/// <param name="memberName">The name of the member to be set.</param>

		internal static delegate*<nint, string, string, void> NetworkStateChanged2 = &___NetworkStateChanged2;
		internal static delegate* unmanaged[Cdecl]<nint, String192*, String192*, void> __NetworkStateChanged2;
		private static void ___NetworkStateChanged2(nint entity, string className, string memberName)
		{
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__NetworkStateChanged2(entity, &__className, &__memberName);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
		}

		/// <summary>
		/// Retrieves the count of values that an entity schema's array can store.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <returns>Size of array (in elements) or 0 if schema is not an array.</returns>

		internal static delegate*<int, string, string, int> GetEntSchemaArraySize = &___GetEntSchemaArraySize;
		internal static delegate* unmanaged[Cdecl]<int, String192*, String192*, int> __GetEntSchemaArraySize;
		private static int ___GetEntSchemaArraySize(int entityHandle, string className, string memberName)
		{
			int __retVal;
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__retVal = __GetEntSchemaArraySize(entityHandle, &__className, &__memberName);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
			return __retVal;
		}

		/// <summary>
		/// Retrieves an integer value from an entity's schema.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>
		/// <returns>An integer value at the given schema offset.</returns>

		internal static delegate*<int, string, string, int, long> GetEntSchema = &___GetEntSchema;
		internal static delegate* unmanaged[Cdecl]<int, String192*, String192*, int, long> __GetEntSchema;
		private static long ___GetEntSchema(int entityHandle, string className, string memberName, int element)
		{
			long __retVal;
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__retVal = __GetEntSchema(entityHandle, &__className, &__memberName, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
			return __retVal;
		}

		/// <summary>
		/// Sets an integer value in an entity's schema.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="value">The integer value to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>

		internal static delegate*<int, string, string, long, Bool8, int, void> SetEntSchema = &___SetEntSchema;
		internal static delegate* unmanaged[Cdecl]<int, String192*, String192*, long, Bool8, int, void> __SetEntSchema;
		private static void ___SetEntSchema(int entityHandle, string className, string memberName, long value, Bool8 changeState, int element)
		{
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__SetEntSchema(entityHandle, &__className, &__memberName, value, changeState, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
		}

		/// <summary>
		/// Retrieves a float value from an entity's schema.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>
		/// <returns>A float value at the given schema offset.</returns>

		internal static delegate*<int, string, string, int, double> GetEntSchemaFloat = &___GetEntSchemaFloat;
		internal static delegate* unmanaged[Cdecl]<int, String192*, String192*, int, double> __GetEntSchemaFloat;
		private static double ___GetEntSchemaFloat(int entityHandle, string className, string memberName, int element)
		{
			double __retVal;
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__retVal = __GetEntSchemaFloat(entityHandle, &__className, &__memberName, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
			return __retVal;
		}

		/// <summary>
		/// Sets a float value in an entity's schema.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="value">The float value to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>

		internal static delegate*<int, string, string, double, Bool8, int, void> SetEntSchemaFloat = &___SetEntSchemaFloat;
		internal static delegate* unmanaged[Cdecl]<int, String192*, String192*, double, Bool8, int, void> __SetEntSchemaFloat;
		private static void ___SetEntSchemaFloat(int entityHandle, string className, string memberName, double value, Bool8 changeState, int element)
		{
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__SetEntSchemaFloat(entityHandle, &__className, &__memberName, value, changeState, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
		}

		/// <summary>
		/// Retrieves a string value from an entity's schema.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>
		/// <returns>A string value at the given schema offset.</returns>

		internal static delegate*<int, string, string, int, string> GetEntSchemaString = &___GetEntSchemaString;
		internal static delegate* unmanaged[Cdecl]<int, String192*, String192*, int, String192> __GetEntSchemaString;
		private static string ___GetEntSchemaString(int entityHandle, string className, string memberName, int element)
		{
			string __retVal;
			String192 __retVal_native;
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__retVal_native = __GetEntSchemaString(entityHandle, &__className, &__memberName, element);
				// Unmarshal - Convert native data to managed data.
				__retVal = NativeMethods.GetStringData(&__retVal_native);

			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__retVal_native);
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
			return __retVal;
		}

		/// <summary>
		/// Sets a string value in an entity's schema.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="value">The string value to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>

		internal static delegate*<int, string, string, string, Bool8, int, void> SetEntSchemaString = &___SetEntSchemaString;
		internal static delegate* unmanaged[Cdecl]<int, String192*, String192*, String192*, Bool8, int, void> __SetEntSchemaString;
		private static void ___SetEntSchemaString(int entityHandle, string className, string memberName, string value, Bool8 changeState, int element)
		{
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);
			var __value = NativeMethods.ConstructString(value);

			try {
				__SetEntSchemaString(entityHandle, &__className, &__memberName, &__value, changeState, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
				NativeMethods.DestroyString(&__value);
			}
		}

		/// <summary>
		/// Retrieves a vector value from an entity's schema.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>
		/// <returns>A string value at the given schema offset.</returns>

		internal static delegate*<int, string, string, int, Vector3> GetEntSchemaVector3D = &___GetEntSchemaVector3D;
		internal static delegate* unmanaged[Cdecl]<int, String192*, String192*, int, Vector3> __GetEntSchemaVector3D;
		private static Vector3 ___GetEntSchemaVector3D(int entityHandle, string className, string memberName, int element)
		{
			Vector3 __retVal;
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__retVal = __GetEntSchemaVector3D(entityHandle, &__className, &__memberName, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
			return __retVal;
		}

		/// <summary>
		/// Sets a vector value in an entity's schema.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="value">The vector value to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>

		internal static delegate*<int, string, string, Vector3, Bool8, int, void> SetEntSchemaVector3D = &___SetEntSchemaVector3D;
		internal static delegate* unmanaged[Cdecl]<int, String192*, String192*, Vector3*, Bool8, int, void> __SetEntSchemaVector3D;
		private static void ___SetEntSchemaVector3D(int entityHandle, string className, string memberName, Vector3 value, Bool8 changeState, int element)
		{
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__SetEntSchemaVector3D(entityHandle, &__className, &__memberName, &value, changeState, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
		}

		/// <summary>
		/// Retrieves a vector value from an entity's schema.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>
		/// <returns>A string value at the given schema offset.</returns>

		internal static delegate*<int, string, string, int, Vector2> GetEntSchemaVector2D = &___GetEntSchemaVector2D;
		internal static delegate* unmanaged[Cdecl]<int, String192*, String192*, int, Vector2> __GetEntSchemaVector2D;
		private static Vector2 ___GetEntSchemaVector2D(int entityHandle, string className, string memberName, int element)
		{
			Vector2 __retVal;
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__retVal = __GetEntSchemaVector2D(entityHandle, &__className, &__memberName, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
			return __retVal;
		}

		/// <summary>
		/// Sets a vector value in an entity's schema.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="value">The vector value to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>

		internal static delegate*<int, string, string, Vector2, Bool8, int, void> SetEntSchemaVector2D = &___SetEntSchemaVector2D;
		internal static delegate* unmanaged[Cdecl]<int, String192*, String192*, Vector2*, Bool8, int, void> __SetEntSchemaVector2D;
		private static void ___SetEntSchemaVector2D(int entityHandle, string className, string memberName, Vector2 value, Bool8 changeState, int element)
		{
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__SetEntSchemaVector2D(entityHandle, &__className, &__memberName, &value, changeState, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
		}

		/// <summary>
		/// Retrieves a vector value from an entity's schema.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>
		/// <returns>A string value at the given schema offset.</returns>

		internal static delegate*<int, string, string, int, Vector4> GetEntSchemaVector4D = &___GetEntSchemaVector4D;
		internal static delegate* unmanaged[Cdecl]<int, String192*, String192*, int, Vector4> __GetEntSchemaVector4D;
		private static Vector4 ___GetEntSchemaVector4D(int entityHandle, string className, string memberName, int element)
		{
			Vector4 __retVal;
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__retVal = __GetEntSchemaVector4D(entityHandle, &__className, &__memberName, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
			return __retVal;
		}

		/// <summary>
		/// Sets a vector value in an entity's schema.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="value">The vector value to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>

		internal static delegate*<int, string, string, Vector4, Bool8, int, void> SetEntSchemaVector4D = &___SetEntSchemaVector4D;
		internal static delegate* unmanaged[Cdecl]<int, String192*, String192*, Vector4*, Bool8, int, void> __SetEntSchemaVector4D;
		private static void ___SetEntSchemaVector4D(int entityHandle, string className, string memberName, Vector4 value, Bool8 changeState, int element)
		{
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__SetEntSchemaVector4D(entityHandle, &__className, &__memberName, &value, changeState, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
		}

		/// <summary>
		/// Retrieves an entity handle from an entity's schema.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>
		/// <returns>A string value at the given schema offset.</returns>

		internal static delegate*<int, string, string, int, int> GetEntSchemaEnt = &___GetEntSchemaEnt;
		internal static delegate* unmanaged[Cdecl]<int, String192*, String192*, int, int> __GetEntSchemaEnt;
		private static int ___GetEntSchemaEnt(int entityHandle, string className, string memberName, int element)
		{
			int __retVal;
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__retVal = __GetEntSchemaEnt(entityHandle, &__className, &__memberName, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
			return __retVal;
		}

		/// <summary>
		/// Sets an entity handle in an entity's schema.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="className">The name of the class.</param>
		/// <param name="memberName">The name of the schema member.</param>
		/// <param name="value">The entity handle to set.</param>
		/// <param name="changeState">If true, change will be sent over the network.</param>
		/// <param name="element">Element # (starting from 0) if schema is an array.</param>

		internal static delegate*<int, string, string, int, Bool8, int, void> SetEntSchemaEnt = &___SetEntSchemaEnt;
		internal static delegate* unmanaged[Cdecl]<int, String192*, String192*, int, Bool8, int, void> __SetEntSchemaEnt;
		private static void ___SetEntSchemaEnt(int entityHandle, string className, string memberName, int value, Bool8 changeState, int element)
		{
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__SetEntSchemaEnt(entityHandle, &__className, &__memberName, value, changeState, element);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
		}

		/// <summary>
		/// Updates the networked state of a schema field for a given entity handle.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which the value is to be retrieved.</param>
		/// <param name="className">The name of the class that contains the member.</param>
		/// <param name="memberName">The name of the member to be set.</param>

		internal static delegate*<int, string, string, void> NetworkStateChanged = &___NetworkStateChanged;
		internal static delegate* unmanaged[Cdecl]<int, String192*, String192*, void> __NetworkStateChanged;
		private static void ___NetworkStateChanged(int entityHandle, string className, string memberName)
		{
			var __className = NativeMethods.ConstructString(className);
			var __memberName = NativeMethods.ConstructString(memberName);

			try {
				__NetworkStateChanged(entityHandle, &__className, &__memberName);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyString(&__className);
				NativeMethods.DestroyString(&__memberName);
			}
		}

		/// <summary>
		/// Creates a new timer that executes a callback function at specified intervals.
		/// </summary>
		/// <param name="interval">The time interval in seconds between each callback execution.</param>
		/// <param name="callback">The function to be called when the timer expires.</param>
		/// <param name="flags">Flags that modify the behavior of the timer (e.g., no-map change, repeating).</param>
		/// <param name="userData">An array intended to hold user-related data, allowing for elements of any type.</param>
		/// <returns>A pointer to the newly created CTimer object, or nullptr if the timer could not be created.</returns>
		/// <remarks>
		/// Callback TimerCallback: This function is invoked when a timer event occurs. It handles the timer-related logic and performs necessary actions based on the event.
		/// - Parameter timer: A 64-bit pointer to the timer object. This object contains the details of the timer, such as its current state, duration, and any associated data.
		/// - Parameter userData: An array intended to hold user-related data, allowing for elements of any type.
		/// - Returns: This function does not return any value. All necessary operations are performed directly during the callback. (void)
		/// </remarks>

		internal static delegate*<float, TimerCallback, int, object?[], nint> CreateTimer = &___CreateTimer;
		internal static delegate* unmanaged[Cdecl]<float, nint, int, Vector192*, nint> __CreateTimer;
		private static nint ___CreateTimer(float interval, TimerCallback callback, int flags, object?[] userData)
		{
			nint __retVal;
			var __callback = Marshalling.GetFunctionPointerForDelegate(callback);
			var __userData = NativeMethods.ConstructVectorVariant(userData, userData.Length);

			try {
				__retVal = __CreateTimer(interval, __callback, flags, &__userData);
			}
			finally {
				// Perform cleanup.
				NativeMethods.DestroyVectorVariant(&__userData);
			}
			return __retVal;
		}

		/// <summary>
		/// Stops and removes an existing timer.
		/// </summary>
		/// <param name="timer">A pointer to the CTimer object to be stopped and removed.</param>

		internal static delegate*<nint, void> KillsTimer = &___KillsTimer;
		internal static delegate* unmanaged[Cdecl]<nint, void> __KillsTimer;
		private static void ___KillsTimer(nint timer)
		{
			__KillsTimer(timer);
		}

		/// <summary>
		/// Returns the number of seconds in between game server ticks.
		/// </summary>
		/// <returns>The tick interval value.</returns>

		internal static delegate*<float> GetTickInterval = &___GetTickInterval;
		internal static delegate* unmanaged[Cdecl]<float> __GetTickInterval;
		private static float ___GetTickInterval()
		{
			float __retVal = __GetTickInterval();
			return __retVal;
		}

		/// <summary>
		/// Returns the simulated game time.
		/// </summary>
		/// <returns>The ticked time value.</returns>

		internal static delegate*<double> GetTickedTime = &___GetTickedTime;
		internal static delegate* unmanaged[Cdecl]<double> __GetTickedTime;
		private static double ___GetTickedTime()
		{
			double __retVal = __GetTickedTime();
			return __retVal;
		}

		/// <summary>
		/// Register callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnClientConnectCallback: Called on client connection. If you return true, the client will be allowed in the server. If you return false (or return nothing), the client will be rejected. If the client is rejected by this forward or any other, OnClientDisconnect will not be called.<br>Note: Do not write to rejectmsg if you plan on returning true. If multiple plugins write to the string buffer, it is not defined which plugin's string will be shown to the client, but it is guaranteed one of them will.
		/// - Parameter clientIndex: The client index
		/// - Parameter name: The client name
		/// - Parameter networkId: The client id
		/// - Returns: True to validate client's connection, false to refuse it. (bool)
		/// </remarks>

		internal static delegate*<OnClientConnectCallback, void> OnClientConnect_Register = &___OnClientConnect_Register;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnClientConnect_Register;
		private static void ___OnClientConnect_Register(OnClientConnectCallback callback)
		{
			var __callback = Marshalling.GetFunctionPointerForDelegate(callback);

			__OnClientConnect_Register(__callback);
		}

		/// <summary>
		/// Unregister callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnClientConnectCallback: Called on client connection. If you return true, the client will be allowed in the server. If you return false (or return nothing), the client will be rejected. If the client is rejected by this forward or any other, OnClientDisconnect will not be called.<br>Note: Do not write to rejectmsg if you plan on returning true. If multiple plugins write to the string buffer, it is not defined which plugin's string will be shown to the client, but it is guaranteed one of them will.
		/// - Parameter clientIndex: The client index
		/// - Parameter name: The client name
		/// - Parameter networkId: The client id
		/// - Returns: True to validate client's connection, false to refuse it. (bool)
		/// </remarks>

		internal static delegate*<OnClientConnectCallback, void> OnClientConnect_Unregister = &___OnClientConnect_Unregister;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnClientConnect_Unregister;
		private static void ___OnClientConnect_Unregister(OnClientConnectCallback callback)
		{
			var __callback = Marshalling.GetFunctionPointerForDelegate(callback);

			__OnClientConnect_Unregister(__callback);
		}

		/// <summary>
		/// Register callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnClientConnect_PostCallback: Called on client connection.
		/// - Parameter clientIndex: The client index
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnClientConnect_PostCallback, void> OnClientConnect_Post_Register = &___OnClientConnect_Post_Register;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnClientConnect_Post_Register;
		private static void ___OnClientConnect_Post_Register(OnClientConnect_PostCallback callback)
		{
			__OnClientConnect_Post_Register(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Unregister callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnClientConnect_PostCallback: Called on client connection.
		/// - Parameter clientIndex: The client index
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnClientConnect_PostCallback, void> OnClientConnect_Post_Unregister = &___OnClientConnect_Post_Unregister;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnClientConnect_Post_Unregister;
		private static void ___OnClientConnect_Post_Unregister(OnClientConnect_PostCallback callback)
		{
			__OnClientConnect_Post_Unregister(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Register callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnClientConnectedCallback: Called once a client successfully connects. This callback is paired with OnClientDisconnect.
		/// - Parameter clientIndex: The client index
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnClientConnectedCallback, void> OnClientConnected_Register = &___OnClientConnected_Register;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnClientConnected_Register;
		private static void ___OnClientConnected_Register(OnClientConnectedCallback callback)
		{
			__OnClientConnected_Register(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Unregister callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnClientConnectedCallback: Called once a client successfully connects. This callback is paired with OnClientDisconnect.
		/// - Parameter clientIndex: The client index
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnClientConnectedCallback, void> OnClientConnected_Unregister = &___OnClientConnected_Unregister;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnClientConnected_Unregister;
		private static void ___OnClientConnected_Unregister(OnClientConnectedCallback callback)
		{
			__OnClientConnected_Unregister(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Register callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnClientPutInServerCallback: Called when a client is entering the game.
		/// - Parameter clientIndex: The client index
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnClientPutInServerCallback, void> OnClientPutInServer_Register = &___OnClientPutInServer_Register;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnClientPutInServer_Register;
		private static void ___OnClientPutInServer_Register(OnClientPutInServerCallback callback)
		{
			__OnClientPutInServer_Register(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Unregister callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnClientPutInServerCallback: Called when a client is entering the game.
		/// - Parameter clientIndex: The client index
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnClientPutInServerCallback, void> OnClientPutInServer_Unregister = &___OnClientPutInServer_Unregister;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnClientPutInServer_Unregister;
		private static void ___OnClientPutInServer_Unregister(OnClientPutInServerCallback callback)
		{
			__OnClientPutInServer_Unregister(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Register callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnClientDisconnectCallback: Called when a client is disconnecting from the server.
		/// - Parameter clientIndex: The client index
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnClientDisconnectCallback, void> OnClientDisconnect_Register = &___OnClientDisconnect_Register;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnClientDisconnect_Register;
		private static void ___OnClientDisconnect_Register(OnClientDisconnectCallback callback)
		{
			__OnClientDisconnect_Register(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Unregister callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnClientDisconnectCallback: Called when a client is disconnecting from the server.
		/// - Parameter clientIndex: The client index
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnClientDisconnectCallback, void> OnClientDisconnect_Unregister = &___OnClientDisconnect_Unregister;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnClientDisconnect_Unregister;
		private static void ___OnClientDisconnect_Unregister(OnClientDisconnectCallback callback)
		{
			__OnClientDisconnect_Unregister(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Register callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnClientDisconnect_PostCallback: Called when a client is disconnected from the server.
		/// - Parameter clientIndex: The client index
		/// - Parameter reason: The reason for disconnect
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnClientDisconnect_PostCallback, void> OnClientDisconnect_Post_Register = &___OnClientDisconnect_Post_Register;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnClientDisconnect_Post_Register;
		private static void ___OnClientDisconnect_Post_Register(OnClientDisconnect_PostCallback callback)
		{
			__OnClientDisconnect_Post_Register(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Unregister callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnClientDisconnect_PostCallback: Called when a client is disconnected from the server.
		/// - Parameter clientIndex: The client index
		/// - Parameter reason: The reason for disconnect
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnClientDisconnect_PostCallback, void> OnClientDisconnect_Post_Unregister = &___OnClientDisconnect_Post_Unregister;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnClientDisconnect_Post_Unregister;
		private static void ___OnClientDisconnect_Post_Unregister(OnClientDisconnect_PostCallback callback)
		{
			__OnClientDisconnect_Post_Unregister(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Register callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnClientActiveCallback: Called when a client is activated by the game.
		/// - Parameter clientIndex: The client index
		/// - Parameter isActive: Active state
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnClientActiveCallback, void> OnClientActive_Register = &___OnClientActive_Register;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnClientActive_Register;
		private static void ___OnClientActive_Register(OnClientActiveCallback callback)
		{
			__OnClientActive_Register(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Unregister callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnClientActiveCallback: Called when a client is activated by the game.
		/// - Parameter clientIndex: The client index
		/// - Parameter isActive: Active state
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnClientActiveCallback, void> OnClientActive_Unregister = &___OnClientActive_Unregister;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnClientActive_Unregister;
		private static void ___OnClientActive_Unregister(OnClientActiveCallback callback)
		{
			__OnClientActive_Unregister(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Register callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnClientFullyConnectCallback: Called when a client is fully connected to the game.
		/// - Parameter clientIndex: The client index
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnClientFullyConnectCallback, void> OnClientFullyConnect_Register = &___OnClientFullyConnect_Register;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnClientFullyConnect_Register;
		private static void ___OnClientFullyConnect_Register(OnClientFullyConnectCallback callback)
		{
			__OnClientFullyConnect_Register(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Unregister callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnClientFullyConnectCallback: Called when a client is fully connected to the game.
		/// - Parameter clientIndex: The client index
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnClientFullyConnectCallback, void> OnClientFullyConnect_Unregister = &___OnClientFullyConnect_Unregister;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnClientFullyConnect_Unregister;
		private static void ___OnClientFullyConnect_Unregister(OnClientFullyConnectCallback callback)
		{
			__OnClientFullyConnect_Unregister(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Register callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnLevelInitCallback: Called when the map starts loading.
		/// - Parameter mapName: The name of the map
		/// - Parameter mapEntities: The entities of the map
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnLevelInitCallback, void> OnLevelInit_Register = &___OnLevelInit_Register;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnLevelInit_Register;
		private static void ___OnLevelInit_Register(OnLevelInitCallback callback)
		{
			var __callback = Marshalling.GetFunctionPointerForDelegate(callback);

			__OnLevelInit_Register(__callback);
		}

		/// <summary>
		/// Unregister callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnLevelInitCallback: Called when the map starts loading.
		/// - Parameter mapName: The name of the map
		/// - Parameter mapEntities: The entities of the map
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnLevelInitCallback, void> OnLevelInit_Unregister = &___OnLevelInit_Unregister;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnLevelInit_Unregister;
		private static void ___OnLevelInit_Unregister(OnLevelInitCallback callback)
		{
			var __callback = Marshalling.GetFunctionPointerForDelegate(callback);

			__OnLevelInit_Unregister(__callback);
		}

		/// <summary>
		/// Register callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnLevelShutdownCallback: Called right before a map ends.
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnLevelShutdownCallback, void> OnLevelShutdown_Register = &___OnLevelShutdown_Register;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnLevelShutdown_Register;
		private static void ___OnLevelShutdown_Register(OnLevelShutdownCallback callback)
		{
			__OnLevelShutdown_Register(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Unregister callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnLevelShutdownCallback: Called right before a map ends.
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnLevelShutdownCallback, void> OnLevelShutdown_Unregister = &___OnLevelShutdown_Unregister;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnLevelShutdown_Unregister;
		private static void ___OnLevelShutdown_Unregister(OnLevelShutdownCallback callback)
		{
			__OnLevelShutdown_Unregister(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Register callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnEntitySpawnedCallback: Called when an entity is spawned.
		/// - Parameter entity: The spawned entity instance
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnEntitySpawnedCallback, void> OnEntitySpawned_Register = &___OnEntitySpawned_Register;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnEntitySpawned_Register;
		private static void ___OnEntitySpawned_Register(OnEntitySpawnedCallback callback)
		{
			__OnEntitySpawned_Register(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Unregister callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnEntitySpawnedCallback: Called when an entity is spawned.
		/// - Parameter entity: The spawned entity instance
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnEntitySpawnedCallback, void> OnEntitySpawned_Unregister = &___OnEntitySpawned_Unregister;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnEntitySpawned_Unregister;
		private static void ___OnEntitySpawned_Unregister(OnEntitySpawnedCallback callback)
		{
			__OnEntitySpawned_Unregister(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Register callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnEntityCreatedCallback: Called when an entity is created.
		/// - Parameter entity: The created entity instance
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnEntityCreatedCallback, void> OnEntityCreated_Register = &___OnEntityCreated_Register;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnEntityCreated_Register;
		private static void ___OnEntityCreated_Register(OnEntityCreatedCallback callback)
		{
			__OnEntityCreated_Register(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Unregister callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnEntityCreatedCallback: Called when an entity is created.
		/// - Parameter entity: The created entity instance
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnEntityCreatedCallback, void> OnEntityCreated_Unregister = &___OnEntityCreated_Unregister;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnEntityCreated_Unregister;
		private static void ___OnEntityCreated_Unregister(OnEntityCreatedCallback callback)
		{
			__OnEntityCreated_Unregister(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Register callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnEntityDeletedCallback: Called when when an entity is destroyed.
		/// - Parameter entity: The deleted entity instance
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnEntityDeletedCallback, void> OnEntityDeleted_Register = &___OnEntityDeleted_Register;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnEntityDeleted_Register;
		private static void ___OnEntityDeleted_Register(OnEntityDeletedCallback callback)
		{
			__OnEntityDeleted_Register(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Unregister callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnEntityDeletedCallback: Called when when an entity is destroyed.
		/// - Parameter entity: The deleted entity instance
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnEntityDeletedCallback, void> OnEntityDeleted_Unregister = &___OnEntityDeleted_Unregister;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnEntityDeleted_Unregister;
		private static void ___OnEntityDeleted_Unregister(OnEntityDeletedCallback callback)
		{
			__OnEntityDeleted_Unregister(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Register callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnEntityParentChangedCallback: When an entity is reparented to another entity.
		/// - Parameter entity: The entity whose parent changed
		/// - Parameter newParent: The new parent entity instance
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnEntityParentChangedCallback, void> OnEntityParentChanged_Register = &___OnEntityParentChanged_Register;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnEntityParentChanged_Register;
		private static void ___OnEntityParentChanged_Register(OnEntityParentChangedCallback callback)
		{
			__OnEntityParentChanged_Register(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Unregister callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnEntityParentChangedCallback: When an entity is reparented to another entity.
		/// - Parameter entity: The entity whose parent changed
		/// - Parameter newParent: The new parent entity instance
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnEntityParentChangedCallback, void> OnEntityParentChanged_Unregister = &___OnEntityParentChanged_Unregister;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnEntityParentChanged_Unregister;
		private static void ___OnEntityParentChanged_Unregister(OnEntityParentChangedCallback callback)
		{
			__OnEntityParentChanged_Unregister(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Register callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnServerStartupCallback: Called on every server startup.
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnServerStartupCallback, void> OnServerStartup_Register = &___OnServerStartup_Register;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnServerStartup_Register;
		private static void ___OnServerStartup_Register(OnServerStartupCallback callback)
		{
			__OnServerStartup_Register(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Unregister callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnServerStartupCallback: Called on every server startup.
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnServerStartupCallback, void> OnServerStartup_Unregister = &___OnServerStartup_Unregister;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnServerStartup_Unregister;
		private static void ___OnServerStartup_Unregister(OnServerStartupCallback callback)
		{
			__OnServerStartup_Unregister(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Register callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnServerActivateCallback: Called on every server activate.
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnServerActivateCallback, void> OnServerActivate_Register = &___OnServerActivate_Register;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnServerActivate_Register;
		private static void ___OnServerActivate_Register(OnServerActivateCallback callback)
		{
			__OnServerActivate_Register(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Unregister callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnServerActivateCallback: Called on every server activate.
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnServerActivateCallback, void> OnServerActivate_Unregister = &___OnServerActivate_Unregister;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnServerActivate_Unregister;
		private static void ___OnServerActivate_Unregister(OnServerActivateCallback callback)
		{
			__OnServerActivate_Unregister(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Register callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnGameFrameCallback: Called before every server frame. Note that you should avoid doing expensive computations or declaring large local arrays.
		/// - Parameter simulating: 
		/// - Parameter firstTick: 
		/// - Parameter lastTick: 
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnGameFrameCallback, void> OnGameFrame_Register = &___OnGameFrame_Register;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnGameFrame_Register;
		private static void ___OnGameFrame_Register(OnGameFrameCallback callback)
		{
			__OnGameFrame_Register(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Unregister callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnGameFrameCallback: Called before every server frame. Note that you should avoid doing expensive computations or declaring large local arrays.
		/// - Parameter simulating: 
		/// - Parameter firstTick: 
		/// - Parameter lastTick: 
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnGameFrameCallback, void> OnGameFrame_Unregister = &___OnGameFrame_Unregister;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnGameFrame_Unregister;
		private static void ___OnGameFrame_Unregister(OnGameFrameCallback callback)
		{
			__OnGameFrame_Unregister(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Register callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnUpdateWhenNotInGameCallback: 
		/// - Parameter deltaTime: Time elapsed since last update
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnUpdateWhenNotInGameCallback, void> OnUpdateWhenNotInGame_Register = &___OnUpdateWhenNotInGame_Register;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnUpdateWhenNotInGame_Register;
		private static void ___OnUpdateWhenNotInGame_Register(OnUpdateWhenNotInGameCallback callback)
		{
			__OnUpdateWhenNotInGame_Register(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Unregister callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnUpdateWhenNotInGameCallback: 
		/// - Parameter deltaTime: Time elapsed since last update
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnUpdateWhenNotInGameCallback, void> OnUpdateWhenNotInGame_Unregister = &___OnUpdateWhenNotInGame_Unregister;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnUpdateWhenNotInGame_Unregister;
		private static void ___OnUpdateWhenNotInGame_Unregister(OnUpdateWhenNotInGameCallback callback)
		{
			__OnUpdateWhenNotInGame_Unregister(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Register callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnPreWorldUpdateCallback: 
		/// - Parameter simulating: 
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnPreWorldUpdateCallback, void> OnPreWorldUpdate_Register = &___OnPreWorldUpdate_Register;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnPreWorldUpdate_Register;
		private static void ___OnPreWorldUpdate_Register(OnPreWorldUpdateCallback callback)
		{
			__OnPreWorldUpdate_Register(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Unregister callback to event.
		/// </summary>
		/// <param name="callback">Function callback.</param>
		/// <remarks>
		/// Callback OnPreWorldUpdateCallback: 
		/// - Parameter simulating: 
		/// - Returns:  (void)
		/// </remarks>

		internal static delegate*<OnPreWorldUpdateCallback, void> OnPreWorldUpdate_Unregister = &___OnPreWorldUpdate_Unregister;
		internal static delegate* unmanaged[Cdecl]<nint, void> __OnPreWorldUpdate_Unregister;
		private static void ___OnPreWorldUpdate_Unregister(OnPreWorldUpdateCallback callback)
		{
			__OnPreWorldUpdate_Unregister(Marshal.GetFunctionPointerForDelegate(callback));
		}

		/// <summary>
		/// Retrieves the pointer to the current game rules instance.
		/// </summary>
		/// <returns>A pointer to the game rules object.</returns>

		internal static delegate*<nint> GetGameRules = &___GetGameRules;
		internal static delegate* unmanaged[Cdecl]<nint> __GetGameRules;
		private static nint ___GetGameRules()
		{
			nint __retVal = __GetGameRules();
			return __retVal;
		}

		/// <summary>
		/// Forces the round to end with a specified reason and delay.
		/// </summary>
		/// <param name="delay">Time (in seconds) to delay before the next round starts.</param>
		/// <param name="reason">The reason for ending the round, defined by the CSRoundEndReason enum.</param>

		internal static delegate*<float, int, void> TerminateRound = &___TerminateRound;
		internal static delegate* unmanaged[Cdecl]<float, int, void> __TerminateRound;
		private static void ___TerminateRound(float delay, int reason)
		{
			__TerminateRound(delay, reason);
		}

		/// <summary>
		/// Retrieves the weapon VData for a given weapon.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which to retrieve the weapon VData.</param>
		/// <returns>The handle of the entity from which to retrieve the weapon VData.</returns>

		internal static delegate*<int, nint> GetWeaponVData = &___GetWeaponVData;
		internal static delegate* unmanaged[Cdecl]<int, nint> __GetWeaponVData;
		private static nint ___GetWeaponVData(int entityHandle)
		{
			nint __retVal = __GetWeaponVData(entityHandle);
			return __retVal;
		}

		/// <summary>
		/// etrieves the weapon definition index for a given entity handle.
		/// </summary>
		/// <param name="entityHandle">The handle of the entity from which to retrieve the weapon def index.</param>
		/// <returns>The weapon definition index as a `uint16_t`, or 0 if the entity handle is invalid.</returns>

		internal static delegate*<int, ushort> GetWeaponDefIndex = &___GetWeaponDefIndex;
		internal static delegate* unmanaged[Cdecl]<int, ushort> __GetWeaponDefIndex;
		private static ushort ___GetWeaponDefIndex(int entityHandle)
		{
			ushort __retVal = __GetWeaponDefIndex(entityHandle);
			return __retVal;
		}

	}
#pragma warning restore CS0649
}