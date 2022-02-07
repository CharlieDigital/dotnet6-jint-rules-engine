/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { RunRequest } from '../models/RunRequest';
import type { RunResponse } from '../models/RunResponse';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class ScriptService {

    /**
     * @returns RunResponse Success
     * @throws ApiError
     */
    public static runScript({
        requestBody,
    }: {
        requestBody?: RunRequest,
    }): CancelablePromise<RunResponse> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/run',
            body: requestBody,
            mediaType: 'application/json',
        });
    }

}