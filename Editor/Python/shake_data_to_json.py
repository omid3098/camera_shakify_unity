import json
from shake_data import SHAKE_LIST

result = '{\n' + '"' + "entries" + '": [\n'


# loop through the list
for shakeType in SHAKE_LIST.keys():

    result += '\t' + '{\n'
    # add shake type to json item
    result += '\t' + '"'+'Id'+'"'+':' + '"' + shakeType + '",\n'
    for i in range(len(SHAKE_LIST[shakeType])):
        if (i == 0):
            result += '\t' + '"'+'Name'+'"'+':' + '"' + \
                str(SHAKE_LIST[shakeType][i]) + '"' + ',\n'
        if (i == 1):
            result += '\t' + '"'+'FPS'+'"'+':' + \
                str(SHAKE_LIST[shakeType][i]) + ',\n'
        elif (i == 2):
            # pars the keyframes
            for keyframeType in SHAKE_LIST[shakeType][i]:
                # position and rotation keyframes
                if(keyframeType[0] == "location" and keyframeType[1] == 0):
                    result += '\t' + '"'+'PosX'+'"'
                elif(keyframeType[0] == "location" and keyframeType[1] == 1):
                    result += '\t' + '"'+'PosY'+'"'
                elif(keyframeType[0] == "location" and keyframeType[1] == 2):
                    result += '\t' + '"'+'PosZ'+'"'
                elif(keyframeType[0] == "rotation_euler" and keyframeType[1] == 0):
                    result += '\t' + '"'+'RotX'+'"'
                elif(keyframeType[0] == "rotation_euler" and keyframeType[1] == 1):
                    result += '\t' + '"'+'RotY'+'"'
                elif(keyframeType[0] == "rotation_euler" and keyframeType[1] == 2):
                    result += '\t' + '"'+'RotZ'+'"'

                # add keyframes to json item
                for j in range(len(SHAKE_LIST[shakeType][i][keyframeType])):
                    if (j == 0):
                        result += ':{'

                    # separate keyframe time from value
                    result += '"'+str(SHAKE_LIST[shakeType][i][keyframeType][j][0])+'":'+str(
                        SHAKE_LIST[shakeType][i][keyframeType][j][1])

                    if (j != len(SHAKE_LIST[shakeType][i][keyframeType]) - 1):
                        result += ','
                    if (j == len(SHAKE_LIST[shakeType][i][keyframeType]) - 1):
                        result += '}'

                # if this keyframeType is the last keyframeType, don't add a comma
                if (list(SHAKE_LIST[shakeType][i].keys()).index(keyframeType) != len(SHAKE_LIST[shakeType][i]) - 1):
                    result += ','
                result += '\n'

            # finish json item }
            # if its last item in the list, don't add a comma
            if shakeType != list(SHAKE_LIST.keys())[-1]:
                result += '},\n'
            else:
                result += '}\n'

# close json
result += ']\n}'

f = open("ShakeData.json", "w")
f.write(str(result))
f.close()

# print(SHAKE_LIST['INVESTIGATION'][2][('location',0)][0])
