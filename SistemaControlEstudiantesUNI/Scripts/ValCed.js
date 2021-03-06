﻿class IdentityCard {
    constructor(identityCard) {
        // identity card
        this.identityCard = identityCard;

        // identity card numbers
        this.identityCardNumbers = identityCard.replace(/[^0-9]+/g, '');

        // identity card letter
        this.identityCardLetter = identityCard.replace(/[^a-zA-Z]+/g, '');

        // letters
        this.letters = 'ABCDEFGHJKLMNPQRSTUVWXY';

        // municipalities
        this.municipalities = [
          'Boaco',
          'Camoapa',
          'Santa Lucía',
          'San José Del Remate',
          'San Lorenzo',
          'Teustepe',
          'Jinotepe',
          'Diriamba',
          'San Marcos',
          'Santa Teresa',
          'Dolores',
          'La Paz Carazo',
          'El Rosario',
          'La Conquista',
          'Chinandega',
          'Corinto',
          'El Realejo',
          'Chichigalpa',
          'Posoltega',
          'El Viejo',
          'Puerto Morazán',
          'Somotillo',
          'Villa Nueva',
          'Santo Tomás del Norte',
          'Cinco Pinos',
          'San Francisco Del Norte',
          'San Pedro Del Norte',
          'Juigalpa',
          'Acoyapa',
          'Santo Tomás',
          'Villa Sandino',
          'San Pedro de Lóvago',
          'La Libertad',
          'Santo Domingo',
          'Comalapa',
          'San Francisco Cuapa',
          'El Coral',
          'Estelí',
          'Pueblo Nuevo',
          'Condega',
          'San Juan Limay',
          'La Trinidad',
          'San Nicolás',
          'Granada',
          'Nandaime',
          'Diriomo',
          'Diriá',
          'Jinotega',
          'San Rafael Del Norte',
          'San Sebastián Yalí',
          'La Concordia',
          'San José De Bocay',
          'El Cuá Bocay',
          'Santa María Pantasma',
          'León',
          'El Jicaral',
          'La Paz Centro',
          'Santa Rosa Del Peñón',
          'Quetzalguaque',
          'Nagarote',
          'El Sauce',
          'Achuapa',
          'Telica',
          'Larreynaga Malpaisillo',
          'Somoto',
          'Telpaneca',
          'Sn Juan Rio Coco',
          'Palacagüina',
          'Yalagüina',
          'Totogalpa',
          'San Lucas',
          'La Sabanas',
          'San José De Cusmapa',
          'Managua',
          'San Rafael Del Sur',
          'Tipitapa',
          'Villa Carlos Fonseca',
          'San Francisco Libre',
          'Mateare',
          'Ticuantepe',
          'Ciudad Sandino',
          'El Crucero',
          'Masaya',
          'Nindirí',
          'Tisma',
          'Catarina',
          'San Juan Oriente',
          'Niquinohomo',
          'Nandasmo',
          'Masatepe',
          'La Concepción',
          'Matagalpa',
          'San Ramón',
          'Matiguás',
          'Muy Muy',
          'Esquipulas',
          'San Dionisio',
          'San Isidro',
          'Sébaco',
          'Ciudad Darío',
          'Terrabona',
          'Rio Blanco',
          'Tuma La Dalia',
          'Rancho Grande',
          'Ocotal',
          'Santa María',
          'Macuelizo',
          'Dipilto',
          'Ciudad Antigua',
          'Mozonte',
          'San Fernando',
          'El Jícaro',
          'Jalapa',
          'Murra',
          'Quilalí',
          'Wiwilí',
          'Wiwilí Nueva Segovia',
          'San Carlos',
          'El Castillo',
          'San Miguelito',
          'Morrito',
          'San Juan del Norte',
          'El Almendro',
          'Rivas',
          'San Jorge',
          'Buenos Aires',
          'Potosí',
          'Belén',
          'Tola',
          'San Juan Sur',
          'Cárdenas',
          'Moyogalpa',
          'Altagracia',
          'Bluefields',
          'El Rama',
          'Muelle De Los Buelles',
          'La Cruz De Rio Grande',
          'Prinzapolka',
          'Nueva Guinea',
          'Tortuguero',
          'Kukra Hill',
          'Laguna De Perlas',
          'Desembocadura Rio Grande',
          'El Ayote',
          'Puerto Cabezas',
          'Waspán',
          'Siuna',
          'Bonanza',
          'Rosita',
          'Bocana Paiwás',
          'Waslala',
          'Corn Island'
        ];

        // code from municipality
        this.codes = [
          '361',
          '362',
          '363',
          '364',
          '365',
          '366',
          '041',
          '042',
          '043',
          '044',
          '045',
          '046',
          '047',
          '048',
          '081',
          '082',
          '083',
          '084',
          '085',
          '086',
          '087',
          '088',
          '089',
          '090',
          '091',
          '092',
          '093',
          '121',
          '122',
          '123',
          '124',
          '125',
          '126',
          '127',
          '128',
          '129',
          '130',
          '161',
          '162',
          '163',
          '164',
          '165',
          '166',
          '201',
          '202',
          '203',
          '204',
          '241',
          '242',
          '243',
          '244',
          '245',
          '246',
          '247',
          '281',
          '283',
          '284',
          '285',
          '286',
          '287',
          '288',
          '289',
          '290',
          '291',
          '321',
          '322',
          '323',
          '324',
          '325',
          '326',
          '327',
          '328',
          '329',
          '001',
          '002',
          '003',
          '004',
          '005',
          '006',
          '007',
          '008',
          '009',
          '401',
          '402',
          '403',
          '404',
          '405',
          '406',
          '407',
          '408',
          '409',
          '441',
          '442',
          '443',
          '444',
          '445',
          '446',
          '447',
          '448',
          '449',
          '450',
          '451',
          '452',
          '453',
          '481',
          '482',
          '483',
          '484',
          '485',
          '486',
          '487',
          '488',
          '489',
          '490',
          '491',
          '492',
          '493',
          '521',
          '522',
          '523',
          '524',
          '525',
          '526',
          '561',
          '562',
          '563',
          '564',
          '565',
          '566',
          '567',
          '568',
          '569',
          '570',
          '601',
          '603',
          '604',
          '605',
          '606',
          '616',
          '619',
          '624',
          '626',
          '627',
          '628',
          '607',
          '608',
          '610',
          '611',
          '612',
          '615',
          '454',
          '602'
        ];
    }

    isValidMunicipalityCode() {
        return (this.codes.indexOf(this.getMunicipalityCode()) !== -1);
    }

    isValidMunicipalityCodePosition() {
        return this.codes.indexOf(this.getMunicipalityCode());
    }

    isValidLetter() {
        return (this.identityCardLetter === this.getRealLetter())
    }

    getRealLetter() {
        let position = this.identityCardNumbers - Math.floor(this.identityCardNumbers / 23.0) * 23;
        return this.letters.charAt(position);
    }

    getMunicipalityName() {
        return this.municipalities[this.isValidMunicipalityCodePosition()];
    }

    getMunicipalityCode() {
        return this.identityCardNumbers.substring(0, 3);
    }

    validate() {
        let response = {} ;
        response.isValid = false;
        if (!this.isValidMunicipalityCode()) {
            // response.error = {
            // message: 'El código de municipio es inválido',
            //};
        }
        else if (!this.isValidLetter()) {
            //  response.error = {
            //  message: `La letra es inválida, se esperaba ${this.getRealLetter()}`,
            //};
        } else {
            response.isValid = true;
            // response.identityCard = this.identityCard;
            //response.municipality = this.getMunicipalityName();
        }

        return response;
    }





}


function ValirdarCedula(event) {
  
    var cedula = document.getElementById('txtCedula');
     console.log(cedula.value);
     let foo = new IdentityCard(cedula.value);
    
    
    if (foo.validate().isValid === false) {
        event.preventDefault();
      
        alert('Ingrese una cédula válida!');
       
    }
}

 