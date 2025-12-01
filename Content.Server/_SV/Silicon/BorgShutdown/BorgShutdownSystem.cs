// SPDX-FileCopyrightText: 2025 Sector-Vestige contributors
// SPDX-FileCopyrightText: 2025 Sector Vestige contributors (modifications)
// SPDX-FileCopyrightText: 2025 ReboundQ3 <ReboundQ3@gmail.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Server.Power.EntitySystems;
using Content.Server.PowerCell;
using Content.Shared.Actions;
using Content.Shared.Popups;
using Content.Shared.Power.Components;
using Content.Shared.PowerCell.Components;
using Content.Shared._SV.Silicon.BorgShutdown;

namespace Content.Server._SV.Silicon.BorgShutdown;

/// <summary>
/// SV: System that handles borg shutdown/wakeup functionality.
/// </summary>
public sealed class BorgShutdownSystem : EntitySystem
{
    [Dependency] private readonly BatterySystem _battery = default!;
    [Dependency] private readonly PowerCellSystem _powerCell = default!;
    [Dependency] private readonly SharedActionsSystem _actions = default!;
    [Dependency] private readonly SharedPopupSystem _popup = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<BorgShutdownComponent, BorgShutdownActionEvent>(OnShutdownAction);
    }

    private void OnShutdownAction(EntityUid uid, BorgShutdownComponent component, BorgShutdownActionEvent args)
    {
        if (!TryComp<PowerCellSlotComponent>(uid, out var cellSlot))
            return;

        if (!_powerCell.TryGetBatteryFromSlot(uid, out var batteryUid, out var battery, cellSlot))
        {
            _popup.PopupEntity("No power cell installed!", uid, uid);
            return;
        }

        if (component.IsShutdown)
        {
            // Wake up: restore battery charge
            _battery.SetCharge((batteryUid.Value, battery), component.StoredCharge);
            component.IsShutdown = false;
            component.StoredCharge = 0;
            _popup.PopupEntity("Systems online.", uid, uid);
        }
        else
        {
            // Shutdown: save current charge and drain to 0
            component.StoredCharge = battery.CurrentCharge;
            _battery.SetCharge((batteryUid.Value, battery), 0);
            component.IsShutdown = true;
            _popup.PopupEntity("Entering sleep mode...", uid, uid);
        }

        Dirty(uid, component);
        args.Handled = true;
    }
}
