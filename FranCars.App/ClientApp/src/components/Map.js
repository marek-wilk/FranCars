import React from 'react'
import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet';
import 'leaflet-defaulticon-compatibility/dist/leaflet-defaulticon-compatibility.css'
import 'leaflet-defaulticon-compatibility/dist/leaflet-defaulticon-compatibility'

const Map = (props) => {
    const {latitude, longitude, location, warehouseName} = props

    return (
        <MapContainer center={[latitude, longitude]} zoom={13} scrollWheelZoom={false} height={100}>
            <TileLayer 
            attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
            url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png" />
            <Marker position={[latitude, longitude]}>
                <Popup>
                    {warehouseName}, {location}
                </Popup>
            </Marker>
        </MapContainer>
    );
}

export default Map