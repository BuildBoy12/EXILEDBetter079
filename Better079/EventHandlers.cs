﻿// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Better079
{
    using Exiled.Events.EventArgs;

    /// <summary>
    /// Contains all EXILED based events.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnSpawning(SpawningEventArgs)"/>
        public void OnSpawning(SpawningEventArgs ev)
        {
            if (ev.Player.Role == RoleType.Scp079)
            {
                ev.Player.ShowHint(plugin.Translation.SpawnMsg, 10f);
            }
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Scp079.OnGainingExperience(GainingExperienceEventArgs)"/>
        public void OnGainingExperience(GainingExperienceEventArgs ev)
        {
            if (plugin.Config.ExperienceGain.TryGetValue(ev.GainType, out float experience))
            {
                ev.Amount += experience;
            }
        }
    }
}