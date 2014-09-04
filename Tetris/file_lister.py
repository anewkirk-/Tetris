import glob

res = ""
output = open("files_to_rm.txt", 'w')

for i in glob.glob("bin\Release\*.*"):
	res += "delete $INSTDIR\\" + i + "\n"
	
for i in glob.glob("Images\*.*"):
	res += "delete $INSTDIR\\" + i + "\n"
	
for i in glob.glob("Sound\Music\*.*"):
	res += "delete $INSTDIR\\" + i + "\n"
	
for i in glob.glob("Sound\SoundEffects\*.*"):
	res += "delete $INSTDIR\\" + i + "\n"
	
output.write(res)
output.close()