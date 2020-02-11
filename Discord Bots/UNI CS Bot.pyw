# Work with Python 3.7
import discord
from discord.ext import commands
from discord import guild
from discord.utils import get
from random import randint
import fileinput
from time import localtime, strftime



client = discord.Client()

@client.event
async def on_raw_reaction_add(payload):
    logChannel = client.get_channel(629070514224103450)
    guild = client.get_guild(payload.guild_id)
    channel = client.get_channel(payload.channel_id)
    message = await channel.fetch_message(payload.message_id)
    if channel.id == 629066358625140769:
        roleStr = message.content.split('"')[1]
        user = guild.get_member(payload.user_id)
        role = get(guild.roles, name=roleStr)
        if role == None:
            await logChannel.send("I tried adding '"+ str(roleStr)+"' to "+ user.mention +", but the role does not exist\n")
        elif channel.id == 629066358625140769:
            if role not in user.roles:
                await user.add_roles(role)
                await logChannel.send("I added the role '"+ str(role)+ "' to "+ user.mention + "\n")
            else:
                await logChannel.send("I can not add '" + str(role) + "' to " + user.mention + " because they already have the role\n")
    if (message.id == 629544536913477633) and (channel.id == 629543114754752522):
        user = guild.get_member(payload.user_id)
        acceptRole = get(guild.roles, name="Verified")
        newRole = get(guild.roles, name="New Member")
        await user.remove_roles(newRole)
        await user.add_roles(acceptRole)
        await logChannel.send(user.mention + " acknowledged the UNI Policies and agreed to the server rules.")
            
@client.event
async def on_raw_reaction_remove(payload):
    logChannel = client.get_channel(629070514224103450)
    guild = client.get_guild(payload.guild_id)
    channel = client.get_channel(payload.channel_id)
    message = await channel.fetch_message(payload.message_id)
    if channel.id == 629066358625140769:
        roleStr = message.content.split('"')[1]
        user = guild.get_member(payload.user_id)
        role = get(guild.roles, name=roleStr)
        if role == None:
            await logChannel.send("I tried removing '"+ str(roleStr) +"' from " + user.mention + " but the role does not exist\n")
        elif channel.id == 629066358625140769:
            if role in user.roles:
                await user.remove_roles(role)
                await logChannel.send("I removed the role '"+ str(role)+ "' from "+ user.mention +"\n")
            else:
                await logChannel.send("I can not remove '" + str(role)+ "' from " + user.mention + " because they do not have the role\n")

@client.event
async def on_message(message):
    if message.author.bot:
        return
    if message.content.startswith('-help'):
            channel = message.channel
            await channel.send("This is a bot made by Josh. Report any issues to him.\n\nFor now, this bot welcomes new users and manages roles via reactions")
    if message.content.startswith('-memberCount'):
            channel = message.channel
            await channel.send("There are "+str(message.guild.member_count)+" members in the server")
    if message.content.startswith('-roleCount'):
        schoolList = ["All Stars University", "Anzio Girls High School", "BC Freedom High School", "Bellwall Academy", "Blue Division High School", "Bonple High School",
              "Count High School", "Chi-Ha Tan Academy", "Gregor High School", "Jatkosota High School", "Koala Forest High School", "Kuromorimine Girls Academy",
              "Maginot Girls' Academy", "Maple Girls High School", "Neutrality High School", "Ooarai Girls Academy", "Pravda Girls High School", "St. Gloriana Girls Academy",
              "Saunders University High School", "Viggen High School", "West Kureoji Grona Academy"] #update this list with new schools
        if message.channel.id == 636669547667128337: #this id is #school-member-count
            roleDict = {}
            for member in message.guild.members:
                for role in member.roles:
                    if role.name in schoolList:
                        if role not in roleDict:
                            roleDict[role] = 1
                        else:
                            roleDict[role] += 1
            roleList = []
            for key in sorted(roleDict.keys()) :
                roleList.append(key)
                
            sendStr = ''
            for role in roleList:
                sendStr += role.name + " " + str(roleDict[role]) + "\n"
            sendStr = "```School Member Counts\nUpdated at: " + strftime("%Y-%m-%d %H:%M:%S Central\n", localtime())+ "\n" + sendStr + "```"
            await message.channel.send(sendStr)
        

@client.event
async def on_member_join(user):
    logChannel = client.get_channel(629070514224103450)
    welcomeChannel = client.get_channel(623903832665096194)
    guild = client.get_guild(621085287833141249)
    role = get(guild.roles, name="New Member")
    await user.add_roles(role)
    await logChannel.send(user.mention + " joined the server")
    await welcomeChannel.send("Welcome " + user.mention + " to the server!\nPlease read <#621170779991703552> and agree to the policy in <#629543114754752522> by reacting to the message.\n" +
                              "Once you have acknowledged the rules, you will gain access to the server.")

@client.event
async def on_member_remove(user):
    logChannel = client.get_channel(629070514224103450)
    guild = client.get_guild(621085287833141249)
    await logChannel.send(user.mention + " left the server")

            
@client.event
async def on_ready():
    print('Logged in as')
    print(client.user.name)
    print(client.user.id)
    print('------')
    game = discord.Game("-help")
    await client.change_presence(status=discord.Status.online, activity=game)

client.run("")
