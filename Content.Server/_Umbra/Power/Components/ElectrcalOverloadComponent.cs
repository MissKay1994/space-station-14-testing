// SPDX-FileCopyrightText: 2025 Umbra contributors
// SPDX-FileCopyrightText: 2025 Sector Vestige contributors (modifications)
// SPDX-FileCopyrightText: 2025 OnyxTheBrave <131422822+OnyxTheBrave@users.noreply.github.com>
//
// SPDX-License-Identifier: MIT

namespace Content.Server._Umbra.Power.Components;

[RegisterComponent]
public sealed partial class ElectricalOverloadComponent : Component
{
    [DataField]
    public string ExplosionOnOverload = "Default";

    [ViewVariables]
    public DateTime ExplodeAt = DateTime.MaxValue;

    [ViewVariables]
    public DateTime NextBuzz = DateTime.MaxValue;
}
