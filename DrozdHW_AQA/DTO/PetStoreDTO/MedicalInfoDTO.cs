using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DrozdHW_AQA.DTO.PetStoreDTO
{
    public record MedicalInfoDTO(
        bool Vaccinated,
        bool SpayedNeutered,
        bool Microchipped,
        bool SpecialNeeds,
        string HealthNotes
    );
}
