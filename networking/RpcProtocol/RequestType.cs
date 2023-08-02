namespace networking.rpcprotocol;
using System;

[Serializable]
public enum RequestType
{
    LOGIN,LOGOUT,GET_PARTICIPANTS,GET_CONTEST_PARTICIPANTS,GET_NUMBER_OF_PARTICIPANTS,ADD_PARTICIPANT
}