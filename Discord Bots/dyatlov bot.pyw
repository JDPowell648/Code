# Work with Python 3.6
import discord
from discord.ext import commands
from discord import guild
from discord.utils import get
from random import randint
import fileinput
from time import localtime, strftime

client = discord.Client()

@client.event

async def on_message(message):
    assignableRoleList = ["LFG","propaganda","events","MoWAS2","HOI","EU4","Wargame","NSFW"]
    if message.author.bot:
        return
    elif message.guild.id == 587333276767879189:
        if message.content.startswith('-makematch'):
                channel = message.channel
                if message.channel.id == 592112755113459714 or message.channel.id == 587349102950350858:
                    maps=[['Fulda Gap'], ['Second Battle of El Alamein'], ['Frozen Pass'],
                           ['Berlin'], ['Eastern Europe (small)'], ['European Province (large)'],
                           ['Finland'], ['White Rock Fortress'], ['Jungle'],
                           ['Battle of Hürtgen Forest'],
                           ['Ash River'], ['Karelia'], ['Carpathians'], ['Kuban'], ['Kursk'],
                           ['Mozdok'], ['Beach of Normandy', 'Fields of Normandy'],
                           ['Poland (small)', 'Fields of Poland'], ['Port Novorossiysk'],
                           ['Advance to the Rhine'], ['Stalingrad'], ['Tunisia'],
                           ['Sands of Tunisia'], ['Volokolamsk (small)'], ['Surroundings of Volokolamsk'],
                           ['Sinai'], ['Sands of Sinai'], ['38th Parallel'], ['Abandoned Factory'],
                           ['Ardennes'], ['Middle East'], ['Maginot Line'], ['Italy'],
                           ['American Desert'], ['Alaska'], ['Vietnam Hills']]
                    times=['Dawn', 'Morning', 'Noon', 'Day', 'Evening', 'Dusk']
                    weathers=['Clear', 'Good', 'Hazy', 'Thin clouds', 'Cloudy',
                                 'Overcast', 'Blind', 'Rain']
                    k=message.content
                    if len(k.split(" ")) == 1:
                        await channel.send('Your map(s) will be*** \nMap:*** '+str(maps[randint(0,len(maps)-1)][0])+"\n***Time***: "+str(times[randint(0,len(times)-1)])+"\n***Weather***: "+str(weathers[randint(0,len(weathers)-1)]+"\n"))
                    elif len(k.split(" ")) == 2:
                        n = int(k.split()[1])
                        if n > 5:
                            n = 5
                        if n <= 0:
                            n = 1
                        for n in range(n):
                            mapnum = randint(0,len(maps)-1)
                            await channel.send('Match ' + str(n+1) + ' will be: \n***Map:*** '+str(maps[mapnum][0])+"\n***Time:*** "+str(times[randint(0,len(times)-1)])+"\n***Weather:*** "+str(weathers[randint(0,len(weathers)-1)]))
                            maps.remove(maps[mapnum])
                    elif len(k.split(" ")) == 3:
                        if k.split(" ")[2] == "small":
                            maps=[['Abandoned factory'],['Poland'],['Advance to the Rhine'],['Sinai'],['Jungle'],['White Rock Fortress'],['Ash River'],['Eastern Europe (small)']]
                        n = int(k.split()[1])
                        if n > 5:
                            n = 5
                        if n <= 0:
                            n = 1
                        for n in range(n):
                            mapnum = randint(0,len(maps)-1)          
                            await channel.send('Match ' + str(n+1) + ' will be: \n***Map:*** '+str(maps[mapnum][0])+"\n***Time:*** "+str(times[randint(0,len(times)-1)])+"\n***Weather:*** "+str(weathers[randint(0,len(weathers)-1)]+"\n"))
                            maps.remove(maps[mapnum])
                    else:
                        await channel.send("The correct usage of that command is: -makematch (number of matches)")
        if message.content.startswith('-matchresult'):
            fout = open("teamData.csv", 'r+')
            for data in fout:
                if data.split(",")[0] == message.content.split(" ")[1]:
                    fout.write(data.split(",")[0] + "," + str(int(data.split(",")[1]) + 1) + "," + data.split(",")[2])
                elif data.split(",")[0] == message.content.split(" ")[2]:
                    fout.write(data.split(",")[0] + "," + data.split(",")[1] + "," + str(int(data.split(",")[2]) + 1))
                
        if message.content.startswith('-help'):
            channel = message.channel
            await channel.send("This is a bot made for War Thunder: World at War.\nReport any bugs or issues to <@188354820833411072>\n\n***Commands include:***\n-makematch (game count) (small/leave blank) ***for judges only***\n-matchresult ***WIP***\n-Dyatlov\n-memberCount\n-addrole (rolename)\n-removerole (rolename)")
        if "dyatlov" in message.content.lower():
            channel = message.channel
            quoteList = ["3.6 roentgen per hour, not great, not terrible",
                    "You didn't see any graphite because IT'S NOT THERE!",
                    "What is the cost of lies?",
                    "Please tell me, how an RBMK reactor explodes?",
                    "It's the feedwater, been around it all night",
                    "We did everything right",
                    "We did nothing wrong",
                    "Every lie we tell, incurs a debt to truth",
                    "There was nothing sane about Chernobyl",
                    "What's just happened?",
                    "There's a fire in the turbine hall",
                    "You and Toptunov, you morons blew the tank!",
                    "There is no core! It exploded!",
                    "He's in shock, get him out of here",
                    "RBMK reactors don't explode",
                    "Do you taste metal?",
                    "What you're saying is physically impossible, the core can't explode",
                    "Why worry about something that isn't going to happen?",
                    "Oh, that's perfect. We should put that on our money",
                    "https://www.youtube.com/watch?v=yU8qYHm2AJI"]
            await channel.send(str(quoteList[randint(0,len(quoteList) - 1)]))
        if message.content.startswith('-memberCount'):
            channel = message.channel
            await channel.send("There are "+str(message.guild.member_count)+" members in the server")
        if message.content.startswith('-addrole') and message.channel.id == 587350999732060180:
            roleString = ""
            if len(message.content.split(" ")) == 1 or message.content.split(" ")[1] == "help":
                for items in range(0,len(assignableRoleList)):
                    roleString += assignableRoleList[items] + "\n"
                await message.channel.send("I can assign the roles:\n" + roleString)
                return
            role = get(message.author.guild.roles, name=message.content.split(" ")[1])
            if message.content.split(" ")[1] in assignableRoleList and role not in message.author.roles:
                await message.author.add_roles(role)
                await message.channel.send("Succesfully added the '" + message.content.split(" ")[1] + "' role to " + message.author.mention)
            elif message.content.split(" ")[1] not in assignableRoleList:
                await message.channel.send("The role '" + message.content.split(" ")[1] + "' does not exist or I cannot assign it.\nUse '-addrole help' for assignable roles")
            else:
                await message.channel.send("You already the '" + message.content.split(" ")[1] + "' role!")
        if message.content.startswith('-removerole') and message.channel.id == 587350999732060180:
            roleString = ""
            if len(message.content.split(" ")) == 1 or message.content.split(" ")[1] == "help":
                for items in range(0,len(assignableRoleList)):
                    roleString += assignableRoleList[items] + "\n"
                await message.channel.send("I can remove the roles:\n" + roleString)
                return
            role = get(message.author.guild.roles, name=message.content.split(" ")[1])
            if message.content.split(" ")[1] in assignableRoleList and role in message.author.roles:
                role = get(message.author.guild.roles, name=message.content.split(" ")[1])
                await message.author.remove_roles(role)
                await message.channel.send("Succesfully removed the '" + message.content.split(" ")[1] + "' role from " + message.author.mention)
            elif message.content.split(" ")[1] not in assignableRoleList:
                await message.channel.send("The role '" + message.content.split(" ")[1] + "' does not exist or I cannot remove it.\nUse '-removerole help' for removable roles")
            else:
                await message.channel.send("You do not have the '" + message.content.split(" ")[1] + "' role!")

        if message.content.startswith('-teamInfo') and message.channel.id == 587701118335975427:
            fin = open("teamData.csv", 'r')
        

@client.event
async def on_raw_reaction_add(payload):
    guild = client.get_guild(payload.guild_id)
    channel = client.get_channel(payload.channel_id)
    message = await channel.fetch_message(payload.message_id)
    roleStr = message.content.split("-")[1]
    user = guild.get_member(payload.user_id)
    role = get(guild.roles, name=roleStr)
    if role == None:
        print(strftime("%Y-%m-%d %H:%M:%S | ", localtime()),"I tried adding the role",roleStr,"to user",user,"but the role does not exist\n")
    elif channel.id == 627030474107256861:
        if role not in user.roles:
            await user.add_roles(role)
            print(strftime("%Y-%m-%d %H:%M:%S | ", localtime()),"I added the role", role, "to user", user,"\n")
        else:
            print(strftime("%Y-%m-%d %H:%M:%S | ", localtime()),"I can not add the role to User", user, "because they already have the", role, "role\n")
            
@client.event
async def on_raw_reaction_remove(payload):
    guild = client.get_guild(payload.guild_id)
    channel = client.get_channel(payload.channel_id)
    message = await channel.fetch_message(payload.message_id)
    roleStr = message.content.split("-")[1]
    user = guild.get_member(payload.user_id)
    role = get(guild.roles, name=roleStr)
    if role == None:
        print(strftime("%Y-%m-%d %H:%M:%S | ", localtime()),"I tried removing the role",roleStr,"from user",user,"but the role does not exist\n")
    elif channel.id == 627030474107256861:
        if role in user.roles:
            await user.remove_roles(role)
            print(strftime("%Y-%m-%d %H:%M:%S | ", localtime()),"I removed the role", role, "from user", user,"\n")
        else:
            print(strftime("%Y-%m-%d %H:%M:%S | ", localtime()),"I can not remove the role from User", user, "because they do not have the", role, "role\n")

            
@client.event
async def on_ready():
    print('Logged in as')
    print(client.user.name)
    print(client.user.id)
    print('------')
    game = discord.Game("-help")
    await client.change_presence(status=discord.Status.online, activity=game)

client.run("")
