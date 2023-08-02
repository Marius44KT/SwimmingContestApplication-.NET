using System.Collections.Generic;
using Com.Example;

namespace networking.ProtobuffProtocol;

public class ProtoUtils
{
    public static ResponseP createOkResponse()
    {
        return new ResponseP {Type = ResponseP.Types.Type.Ok};
    }
    
    
    public static ResponseP createUpdateResponse()
    {
        return new ResponseP {Type = ResponseP.Types.Type.Update};
    }
    
    
    public static ResponseP createErrorResponse(string message)
    {
        return new ResponseP { Type = ResponseP.Types.Type.Error, Message=message };
    }


    public static ResponseP createLoginResponse(bool loggedIn)
    {
        return new ResponseP { Type = ResponseP.Types.Type.Ok, Boolean=loggedIn};
    }
    
    
    public static ResponseP createGetParticipantiResponse(List<ParticipantDTO> participanti)
    {
        ResponseP response = new ResponseP { Type = ResponseP.Types.Type.Ok };
        foreach(ParticipantDTO p in participanti)
        {
            ParticipantDTOP participantDtop = new ParticipantDTOP { Nume = p.getNume(), Varsta = p.getVarsta(), Stil = p.getStil(), Distanta = p.getDistanta() };
            response.All.Add(participantDtop);
        }
        return response;
    }
    
    
    public static ResponseP createGetSearchedParticipantiResponse(List<ParticipantDTO> participanti)
    {
        ResponseP response = new ResponseP { Type = ResponseP.Types.Type.Ok };
        foreach(ParticipantDTO p in participanti)
        {
            ParticipantDTOP participantDtop = new ParticipantDTOP { Nume = p.getNume(), Varsta = p.getVarsta(), Stil = p.getStil(), Distanta = p.getDistanta() };
            response.Searched.Add(participantDtop);
        }
        return response;
    }


    public static ResponseP createGetNumberOfParticipantsResponse(List<int> statistics)
    {
        ResponseP response = new ResponseP { Type = ResponseP.Types.Type.Ok };
        foreach(int value in statistics)
            response.Statistics.Add(value);
        return response;
    }
}