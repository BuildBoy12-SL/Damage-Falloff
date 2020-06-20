Config Options with their default values:
Note: The values that adjust the formula calculating falloff, especially DistanceDiv, can be pretty touchy so modify at your own risk.

#Whether the plugin should be enabled
DmgFall_Enabled: true
#Minimum distance for damage falloff to activate
DmgFall_MinDist: 10
#Denominator when calculating the exponent to RangeMod
DmgFall_DistanceDiv: 10
#The following three apply to the RangeMod portion of the formula below
#Multiplier when the shooter has no scope attached
DmgFall_NoScope: 0.85
#Multiplier when the shooter has a red/blue dot or holo sight
DmgFall_SmallScope: 0.9
#Multiplier when the shooter has a night vision or sniper sight
DmgFall_LargeScope: 0.95

The formula used here for calculating damage falloff is:
Damage * [RangeMod ^ (Distance/DistanceDiv)]
