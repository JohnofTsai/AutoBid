<template>
    <h3>Vehicle Bidding Total Price</h3>
    <label>Basic price: </label>
    <input type="number" v-model="basePrice"/>
    <br />
    <label>Vehicle type:</label>
    <select v-model="vtype">
        <option :value="0">Common</option>
        <option :value="1">Luxury</option>
    </select>
    <br />
    <button @click="fetchData" class="button button-primary p-2">Calculate</button> 
    <button @click="clear" class="button button-primary p-2">Clear</button>
    <div >
        <h4>Price details</h4>
       <p><label>Base Price:</label>  <span class="p-2"> {{ this.post?.basePrice.toFixed(2) }}</span></p>
       <p><label>Basic User Fee:</label>  <span class="p-2"> {{this.post?.basicUserFee.toFixed(2) }}</span></p>
       <p><label>Seller Special Fee:</label>  <span class="p-2"> {{this.post?.sellerSpecialFee.toFixed(2)}}</span></p>
       <p><label>Association Fee:</label>  <span class="p-2"> {{this.post?.associationFee.toFixed(2)}}</span></p>
       <p><label>StorageFee:</label>  <span class="p-2"> {{this.post?.storageFee.toFixed(2)}}</span></p>
       <p><label>Total:</label> <span class="p-2"> {{this.post?.total.toFixed(2)}}</span></p>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';

    type VehPriceDetails = {
        basePrice: number,
        basicUserFee: number,
        sellerSpecialFee: number,
        associationFee: number,
        storageFee: number,
        total: number
    };

    enum vehType { common = 0, luxury = 1 }

    interface Data {
        basePrice: number,
        vtype: vehType,
        computed: boolean,
        post: null | VehPriceDetails,
        msg: string
    }

    export default defineComponent({
        components: {
        },
        directives: {
        },
        filters: {
        },
        props: {
        },
        data(): Data {
            return {
                computed: false,
                post: null,
                msg: '',
                vtype: vehType.common,
                basePrice: 1000
            };
        },
        methods: {
            fetchData(): void {
                fetch('https://localhost:7203/api/FeesComputing',
                    {
                        method: 'POST',
                        headers: { 'Content-Type': 'application/json' },
                        body: JSON.stringify({
                            price: this.basePrice,
                            vehType: this.vtype
                        })
                    })
                    .then(r => r.json(), e => this.msg = e)
                    .then(json => {
                        this.post = json as VehPriceDetails;
                        this.computed = true;
                        this.msg = "Calculated";
                        return;
                    });
            },
            clear(): void {
                this.msg = '';
                this.computed = false;
                this.basePrice = 1000;
                this.vtype = vehType.common;
                this.post = null;
            }
        }
    });

</script>

<style>
    button {
        margin: 3px;
    }

    label {
        margin-right: 5px;
    }
</style>
