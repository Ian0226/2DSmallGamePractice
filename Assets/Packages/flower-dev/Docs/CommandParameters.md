# Command Parameters
- Using **SPECIAL_CHAR_PARAMS_SEPARATOR (Default ',')** to split the command parameters.
---
### hide
```
[hide, milliSec]
```
|Parameter|Description|Type|Default|
|---|---|---|---|
|milliSec|Waiting time (millisecond)|Integer|1000

### show
```
[show, milliSec]
```
|Parameter|Description|Type|Default|
|---|---|---|---|
|milliSec|Waiting time (millisecond)|Integer|1000

### wait
```
[show, milliSec]
```
|Parameter|Description|Type|Default|
|---|---|---|---|
|milliSec|Waiting time (millisecond)|Integer|

### image
```
[image, key, image_path, x, y, order, effect_name]
```
|Parameter|Description|Type|Default
|---|---|---|---|
|key|Scene object key|String|
|image_path|Image file path|String|
|x|X position|Integer|
|y|Y position|Integer|
|order|Order in the layer|Integer|0
|effect_name|Effect name|String|""

### audio
```
[audio, key, audio_path, loop, volume, effect_name, wait]
```
|Parameter|Description|Type|Default|
|---|---|---|---|
|key|Scene object key|String|
|audio_path|Audio file path|String|
|loop|Audio loop|Bool||
|volume|Audio volume|Float|1|
|effect_name|Effect name|String|""
|wait|Wait until the audio finishes playing|Bool|false
### effect
```
[effect, key, effect_name]
```
|Parameter|Description|Type|Default|
|---|---|---|---|
|key|Scene object key|String|
|effect_name|Effect name|String|

### particle
```
[effect, key, effect_name]
```
|Parameter|Description|Type|Default|
|---|---|---|---|
|key|Scene object key|String|
|particle_path|Particle prefab path|String|
|x|X position|Integer|
|y|Y position|Integer|

### remove
```
[remove, key, effect_name]
```
|Parameter|Description|Type|Default|
|---|---|---|---|
|key|Scene object key|String|
|effect_name|Effect name|String|""

### wait_audio
```
[wait_audio, key]
```
|Parameter|Description|Type|Default|
|---|---|---|---|
|key|Scene object key (audio)|String|

### ui_image
```
[ui_image, key, image_path, x, y, ui_stage_key, effect_name]
```
|Parameter|Description|Type|Default
|---|---|---|---|
|key|Scene object key|String|
|image_path|Image file path|String|
|x|X position|Integer|
|y|Y position|Integer|
|ui_stage_key|The key of UI Stage|String|"default"
|effect_name|Effect name|String|""