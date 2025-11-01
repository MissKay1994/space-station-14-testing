// SPDX-FileCopyrightText: 2025 Wizards Den contributors
// SPDX-FileCopyrightText: 2025 Sector Vestige contributors (modifications)
// SPDX-FileCopyrightText: 2025 ReboundQ3 <ReboundQ3@gmail.com>
//
// SPDX-License-Identifier: MIT

using Content.Shared.Actions;
using Content.Shared.DoAfter;
using Robust.Shared.Serialization;

namespace Content.Shared.Silicon.BorgShutdown;

/// <summary>
/// SV: Action event for toggling borg shutdown state.
/// </summary>
public sealed partial class BorgShutdownActionEvent : InstantActionEvent
{
}

[Serializable, NetSerializable]
public sealed partial class BorgShutdownDoAfterEvent : SimpleDoAfterEvent
{
}
