export type LibeyUser = {
    documentNumber: string
    documentTypeId: number
    documentTypeDescription: string
    name: string
    fathersLastName: string
    mothersLastName: string
    address: string
    ubigeoDescription: string
    provinceDescription: string
    regionDescription: string
    ubigeoCode: string
    provinceCode: string
    regionCode: string
    phone: string
    email: string
    password: string
};

export type TipoDocumento = {
    documentTypeId: number
    documentTypeDescription: string
};

export type Region = {
    regionCode: string
    regionDescription: string
};

export type Province = {
    provinceCode: string
    provinceDescription: string
}

export type Ubigeo = {
    ubigeoCode: string
    ubigeoDescription: string
}