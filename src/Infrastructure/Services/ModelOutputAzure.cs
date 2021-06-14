using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Infrastructure.Services
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class WebServiceOutput0
    {
        [JsonPropertyName("ENFERMEDAD")]
        public string ENFERMEDAD { get; set; }

        [JsonPropertyName("SINTOMA")]
        public string SINTOMA { get; set; }

        [JsonPropertyName("SINTOMA.[Depresión,]")]
        public int SINTOMADepresión { get; set; }

        [JsonPropertyName("SINTOMA.[abdominal,]")]
        public int SINTOMAAbdominal { get; set; }

        [JsonPropertyName("SINTOMA.[aspecto]")]
        public int SINTOMAAspecto { get; set; }

        [JsonPropertyName("SINTOMA.[Aerofagia,]")]
        public int SINTOMAAerofagia { get; set; }

        [JsonPropertyName("SINTOMA.[Cambios]")]
        public int SINTOMACambios { get; set; }

        [JsonPropertyName("SINTOMA.[Dificultad]")]
        public int SINTOMADificultad { get; set; }

        [JsonPropertyName("SINTOMA.[estomago),]")]
        public int SINTOMAEstomago { get; set; }

        [JsonPropertyName("SINTOMA.[tragar,]")]
        public int SINTOMATragar { get; set; }

        [JsonPropertyName("SINTOMA.[(ascitis),]")]
        public int SINTOMAAscitis { get; set; }

        [JsonPropertyName("SINTOMA.[(se]")]
        public int SINTOMASe { get; set; }

        [JsonPropertyName("SINTOMA.[Acumulacion]")]
        public int SINTOMAAcumulacion { get; set; }

        [JsonPropertyName("SINTOMA.[durante]")]
        public int SINTOMADurante { get; set; }

        [JsonPropertyName("SINTOMA.[encima]")]
        public int SINTOMAEncima { get; set; }

        [JsonPropertyName("SINTOMA.[epigastrico]")]
        public int SINTOMAEpigastrico { get; set; }

        [JsonPropertyName("SINTOMA.[evacuación]")]
        public int SINTOMAEvacuación { get; set; }

        [JsonPropertyName("SINTOMA.[frecuente,]")]
        public int SINTOMAFrecuente { get; set; }

        [JsonPropertyName("SINTOMA.[justo]")]
        public int SINTOMAJusto { get; set; }

        [JsonPropertyName("SINTOMA.[liquido]")]
        public int SINTOMALiquido { get; set; }

        [JsonPropertyName("SINTOMA.[por]")]
        public int SINTOMAPor { get; set; }

        [JsonPropertyName("SINTOMA.[siente]")]
        public int SINTOMASiente { get; set; }

        [JsonPropertyName("SINTOMA.[intestinal,]")]
        public int SINTOMAIntestinal { get; set; }

        [JsonPropertyName("SINTOMA.[para]")]
        public int SINTOMAPara { get; set; }

        [JsonPropertyName("SINTOMA.[las]")]
        public int SINTOMALas { get; set; }

        [JsonPropertyName("SINTOMA.[(ictericia),]")]
        public int SINTOMAIctericia { get; set; }

        [JsonPropertyName("SINTOMA.[abdomen]")]
        public int SINTOMAAbdomen { get; set; }

        [JsonPropertyName("SINTOMA.[estomacal]")]
        public int SINTOMAEstomacal { get; set; }

        [JsonPropertyName("SINTOMA.[Color]")]
        public int SINTOMAColor { get; set; }

        [JsonPropertyName("SINTOMA.[amarillento]")]
        public int SINTOMAAmarillento { get; set; }

        [JsonPropertyName("SINTOMA.[ojos]")]
        public int SINTOMAOjos { get; set; }

        [JsonPropertyName("SINTOMA.[piel]")]
        public int SINTOMAPiel { get; set; }


        [JsonPropertyName("SINTOMA.[Diarrea,]")]
        public int SINTOMADiarrea { get; set; }

        [JsonPropertyName("SINTOMA.[los]")]
        public int SINTOMALos { get; set; }

        [JsonPropertyName("SINTOMA.[ardor]")]
        public int SINTOMAArdor { get; set; }

        [JsonPropertyName("SINTOMA.[parte]")]
        public int SINTOMAParte { get; set; }

        [JsonPropertyName("SINTOMA.[superior]")]
        public int SINTOMASuperior { get; set; }

        [JsonPropertyName("SINTOMA.[Acidez]")]
        public int SINTOMAAcidez { get; set; }

        [JsonPropertyName("SINTOMA.[del]")]
        public int SINTOMADel { get; set; }

        [JsonPropertyName("SINTOMA.[Dolor]")]
        public int SINTOMADolor { get; set; }

        [JsonPropertyName("ScoredProbabilities_ANEMIADETIPONOESPECIFICADO")]
        public double ScoredProbabilitiesANEMIADETIPONOESPECIFICADO { get; set; }

        [JsonPropertyName("ScoredProbabilities_ANEMIANUTRICIONALNOESPECIFICADA")]
        public double ScoredProbabilitiesANEMIANUTRICIONALNOESPECIFICADA { get; set; }

        [JsonPropertyName("ScoredProbabilities_CALCULODELAVESICULABILIARSINCOLECISTITIS")]
        public double ScoredProbabilitiesCALCULODELAVESICULABILIARSINCOLECISTITIS { get; set; }

        [JsonPropertyName("ScoredProbabilities_CIRROSISBILIARPRIMARIA")]
        public double ScoredProbabilitiesCIRROSISBILIARPRIMARIA { get; set; }

        [JsonPropertyName("ScoredProbabilities_COLITISYGASTROENTERITISNOINFECCIOSASNOESPECIFICADAS")]
        public double ScoredProbabilitiesCOLITISYGASTROENTERITISNOINFECCIOSASNOESPECIFICADAS { get; set; }

        [JsonPropertyName("ScoredProbabilities_CONSTIPACION")]
        public double ScoredProbabilitiesCONSTIPACION { get; set; }

        [JsonPropertyName("ScoredProbabilities_DISFAGIA")]
        public double ScoredProbabilitiesDISFAGIA { get; set; }

        [JsonPropertyName("ScoredProbabilities_ENFERMEDADDELHIGADONOESPECIFICADA")]
        public double ScoredProbabilitiesENFERMEDADDELHIGADONOESPECIFICADA { get; set; }

        [JsonPropertyName("ScoredProbabilities_ENFERMEDADDELREFLUJOGASTROESOFAGICOSINESOFAGITIS")]
        public double ScoredProbabilitiesENFERMEDADDELREFLUJOGASTROESOFAGICOSINESOFAGITIS { get; set; }

        [JsonPropertyName("ScoredProbabilities_ENFERMEDADDELSISTEMADIGESTIVONOESPECIFICADA")]
        public double ScoredProbabilitiesENFERMEDADDELSISTEMADIGESTIVONOESPECIFICADA { get; set; }

        [JsonPropertyName("ScoredProbabilities_ENFERMEDADDIVERTICULARDELINTESTINOGRUESO")]
        public double ScoredProbabilitiesENFERMEDADDIVERTICULARDELINTESTINOGRUESO { get; set; }

        [JsonPropertyName("ScoredProbabilities_ESOFAGITIS")]
        public double ScoredProbabilitiesESOFAGITIS { get; set; }

        [JsonPropertyName("ScoredProbabilities_FISURAANALNOESPECIFICADA")]
        public double ScoredProbabilitiesFISURAANALNOESPECIFICADA { get; set; }

        [JsonPropertyName("ScoredProbabilities_GASTRITISCRONICANOESPECIFICADA")]
        public double ScoredProbabilitiesGASTRITISCRONICANOESPECIFICADA { get; set; }

        [JsonPropertyName("ScoredProbabilities_GASTRITISNOESPECIFICADA")]
        public double ScoredProbabilitiesGASTRITISNOESPECIFICADA { get; set; }

        [JsonPropertyName("ScoredProbabilities_HEMORRAGIAGASTROINTESTINALNOESPECIFICADA")]
        public double ScoredProbabilitiesHEMORRAGIAGASTROINTESTINALNOESPECIFICADA { get; set; }

        [JsonPropertyName("ScoredProbabilities_HEPATITISAGUDATIPOBSINAGENTEDELTAYSINCOMAHEPATICO")]
        public double ScoredProbabilitiesHEPATITISAGUDATIPOBSINAGENTEDELTAYSINCOMAHEPATICO { get; set; }

        [JsonPropertyName("ScoredProbabilities_HEPATITISAGUDATIPOC")]
        public double ScoredProbabilitiesHEPATITISAGUDATIPOC { get; set; }

        [JsonPropertyName("ScoredProbabilities_HEPATITISAUTOINMUNE")]
        public double ScoredProbabilitiesHEPATITISAUTOINMUNE { get; set; }

        [JsonPropertyName("ScoredProbabilities_HIPERLIPIDEMIANOESPECIFICADA")]
        public double ScoredProbabilitiesHIPERLIPIDEMIANOESPECIFICADA { get; set; }

        [JsonPropertyName("ScoredProbabilities_ICTERICIANOESPECIFICADA")]
        public double ScoredProbabilitiesICTERICIANOESPECIFICADA { get; set; }

        [JsonPropertyName("ScoredProbabilities_OBESIDAD")]
        public double ScoredProbabilitiesOBESIDAD { get; set; }

        [JsonPropertyName("ScoredProbabilities_OBSTRUCCIONDELESOFAGO")]
        public double ScoredProbabilitiesOBSTRUCCIONDELESOFAGO { get; set; }

        [JsonPropertyName("ScoredProbabilities_OTRASCIRROSISDELHIGADOYLASNOESPECIFICADAS")]
        public double ScoredProbabilitiesOTRASCIRROSISDELHIGADOYLASNOESPECIFICADAS { get; set; }

        [JsonPropertyName("ScoredProbabilities_OTRASENFERMEDADESESPECIFICADASDELHIGADO")]
        public double ScoredProbabilitiesOTRASENFERMEDADESESPECIFICADASDELHIGADO { get; set; }

        [JsonPropertyName("ScoredProbabilities_OTRASGASTRITISAGUDAS")]
        public double ScoredProbabilitiesOTRASGASTRITISAGUDAS { get; set; }

        [JsonPropertyName("ScoredProbabilities_PROCTITIS")]
        public double ScoredProbabilitiesPROCTITIS { get; set; }

        [JsonPropertyName("ScoredProbabilities_SINDROMEDELCOLONIRRITABLESINDIARREA")]
        public double ScoredProbabilitiesSINDROMEDELCOLONIRRITABLESINDIARREA { get; set; }

        [JsonPropertyName("ScoredProbabilities_TUMORBENIGNODELCOLONPARTENOESPECIFICADA")]
        public double ScoredProbabilitiesTUMORBENIGNODELCOLONPARTENOESPECIFICADA { get; set; }

        [JsonPropertyName("ScoredProbabilities_TUMORBENIGNODELESTOMAGO")]
        public double ScoredProbabilitiesTUMORBENIGNODELESTOMAGO { get; set; }

        [JsonPropertyName("ScoredProbabilities_TUMORMALIGNODELCOLONPARTENOESPECIFICADA")]
        public double ScoredProbabilitiesTUMORMALIGNODELCOLONPARTENOESPECIFICADA { get; set; }

        [JsonPropertyName("ScoredProbabilities_TUMORMALIGNODELESTOMAGOPARTENOESPECIFICADA")]
        public double ScoredProbabilitiesTUMORMALIGNODELESTOMAGOPARTENOESPECIFICADA { get; set; }

        [JsonPropertyName("ScoredProbabilities_ULCERAPEPTICANOESPECIFICADACOMOAGUDANICRONICA")]
        public double ScoredProbabilitiesULCERAPEPTICANOESPECIFICADACOMOAGUDANICRONICA { get; set; }

        [JsonPropertyName("ScoredLabels")]
        public string ScoredLabels { get; set; }
    }

    public class Results
    {
        [JsonPropertyName("WebServiceOutput0")]
        public List<object> WebServiceOutput0 { get; set; }
    }

    public class ModelOutputAzure
    {
        [JsonPropertyName("Results")]
        public Results Results { get; set; }
    }



}
