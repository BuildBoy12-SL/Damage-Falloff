# Damage Falloff
- Requires [EXILED](https://github.com/galaxy119/EXILED/).

## Configs
- The values that adjust the formula calculating falloff, especially DistanceDiv, can be pretty touchy so modify at your own risk

| Config Option | Value Type | Default Value | Description |
|:------------------------:|:----------:|:-------------:|:------------------------------------------:|
| `minimum_distance` | float | 10 | Minimum distance for damage falloff to activate. |
| `distance_divider` | float | 10 | Denominator when calculating the exponent to RangeMod. |
#The following three apply to the RangeMod portion of the formula below
| `no_scope` | float | 0.85 | Multiplier when the shooter has no scope attached. |
| `small_scope` | float | 0.90 | Multiplier when the shooter has a red/blue dot or holo sight. |
| `large_scope` | float | 0.95 | Multiplier when the shooter has a night vision or sniper sight. |

- The formula used here for calculating damage falloff is __Damage * [RangeMod ^ (Distance/DistanceDiv)]__
